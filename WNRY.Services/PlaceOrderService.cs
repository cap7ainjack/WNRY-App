using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WNRY.Core.Data;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;
using WNRY.Utils.MailKit;

namespace WNRY.Services
{
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly WnryDbContext _dbContext;
        private IMailer _mailService;

        public PlaceOrderService(WnryDbContext wnryDbContext, IMailer mailer)
        {
            _dbContext = wnryDbContext;
            this._mailService = mailer;
        }

        public bool PlaceOrder(PlaceOrderVM vm)
        {
            // TODO: Create user if needed
            // TODO: Order for logged user

            if (vm.Address != null && vm.Address.Region != null
                    && !string.IsNullOrEmpty(vm.Name) && !string.IsNullOrEmpty(vm.Email)
                    && !string.IsNullOrEmpty(vm.Phone)
                    && vm.Products?.Any() == true)
            {

                Order orderToInsert = new Order()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Status = Models.Enums.OrderStatus.New,
                };

                if (!string.IsNullOrEmpty(vm.Password) && vm.Password.Length >= 6) // Create user
                {

                }

                // In case of Guest
                this.AddAddressObje(orderToInsert, vm);
                this.AddContactDetails(orderToInsert, vm);

                this.AddProductsToOrder(orderToInsert, vm);

                this._dbContext.Orders.Add(orderToInsert);
                this._dbContext.SaveChanges();

                // sent e-mail
                string mailBody = this.GenerateMailBody(vm, orderToInsert.Id);
                string orderNumber = orderToInsert.Id.ToString().Substring(0, 18).Replace("-", "").ToUpper();

                this._mailService.SendEmailAsync("botsan@abv.bg", "Нова поръчка № " + orderNumber, mailBody);

                return true;
            }

            return false;
        }

        private string GenerateMailBody(PlaceOrderVM vm, Guid id)
        {
            string result = string.Empty;
            int deliveryPrice = 5; // TODO: Calculate delivery dinamically

            string htmlBodyTemplateFilePath = @"C:\Users\botsa\source\repos\WNRY\WNRY-App.git\WNRY.Utils\Files\email_order_template_placeholders.txt";
            string htmlProductTemplate = @"C:\Users\botsa\source\repos\WNRY\WNRY-App.git\WNRY.Utils\Files\Product_template.txt";
            string htmlAddressTemplate = @"C:\Users\botsa\source\repos\WNRY\WNRY-App.git\WNRY.Utils\Files\address_template.txt";

            if (File.Exists(htmlBodyTemplateFilePath))
            {
                string text = File.ReadAllText(htmlBodyTemplateFilePath);

                // ADD PRODUCTS
                var productsIds = vm.Products.Select(a => a.Id);
                IEnumerable<Product> products = this._dbContext.Products.Where(a => productsIds.Any(f => f == a.Id)).ToList();

                StringBuilder sb = new StringBuilder();
                foreach (var product in products)
                {
                    var quantity = vm.Products.FirstOrDefault(a => a.Id == product.Id).Quantity;
                    string productTemplate = File.ReadAllText(htmlProductTemplate);
                    string replacedProductTemplate = productTemplate.Replace("{{{name}}}", product.DisplayName + " " + quantity + "бр.");

                    replacedProductTemplate = replacedProductTemplate.Replace("{{{price}}}", (product.Price * quantity).ToString());

                    sb.AppendLine(replacedProductTemplate);
                }

                string deliveruProductTemplate = File.ReadAllText(htmlProductTemplate);
                string deliveryReplacedProductTemplate = deliveruProductTemplate.Replace("{{{name}}}", "Доставка");
                deliveryReplacedProductTemplate = deliveryReplacedProductTemplate.Replace("{{{price}}}", deliveryPrice.ToString());

                sb.AppendLine(deliveryReplacedProductTemplate);

                text = text.Replace("{{{products}}}", sb.ToString());


                // ADD Total price
                decimal totalPrice = this.GetTotalOrderPrice(products, vm.Products, deliveryPrice);
                text = text.Replace("{{{total}}}", totalPrice.ToString() + " лв.");


                // ADD ADRESS
                if (vm.Address != null)
                {
                    string productTemplate = File.ReadAllText(htmlAddressTemplate);

                    StringBuilder addressSb = new StringBuilder();
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", "Име: " + vm.Name));
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", vm.Address.Region.Text));
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", vm.Address.City));
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", vm.Address.AddressLine));
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", "Телефон: " + vm.Phone));
                    addressSb.AppendLine(productTemplate.Replace("{{{AddressLine}}}", "Плащане: Наложен платеж"));

                    text = text.Replace("{{{address}}}", addressSb.ToString());
                }

                result = text;
            }

            return result;
        }

        private decimal GetTotalOrderPrice(IEnumerable<Product> products1, IEnumerable<OrderProductVm> products2, int deliveryPrice)
        {
            decimal result = 0;
            foreach (var item in products2)
            {
                Product dbProduct = products1.FirstOrDefault(a => a.Id == item.Id);
                if (dbProduct != null)
                {
                    result += (item.Quantity * dbProduct.Price);
                }
            }

            result += deliveryPrice;

            return result;
        }

        private void AddProductsToOrder(Order orderToInsert, PlaceOrderVM vm)
        {
            foreach (OrderProductVm item in vm.Products)
            {
                XRefOrderProducts toIns = new XRefOrderProducts()
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderToInsert.Id,
                    ProductId = item.Id,
                    Quantity = item.Quantity,
                };

                this._dbContext.XRefOrderProducts.Add(toIns);
            }
        }

        private void AddContactDetails(Order orderToInsert, PlaceOrderVM vm)
        {
            Guid? foundedContact = this._dbContext.ContactsDetails
                .Where(a => a.Name == vm.Name
                    && a.Phone == vm.Phone
                    && a.Email == vm.Email)
                .Select(z => z.Id)
                .FirstOrDefault();

            if (foundedContact.HasValue && foundedContact.Value != Guid.Empty)
            {
                orderToInsert.ContactDetailsId = foundedContact.Value;
            }
            else
            {
                ContactDetails cd = new ContactDetails()
                {
                    Id = Guid.NewGuid(),
                    Email = vm.Email,
                    Name = vm.Name,
                    Phone = vm.Phone
                };

                string[] firstAndLastName = vm.Name.Split(' ');
                if (firstAndLastName.Any() && firstAndLastName.Length > 1)
                {
                    cd.FirstName = firstAndLastName[0];
                    cd.LastName = firstAndLastName[1];
                }

                this._dbContext.ContactsDetails.Add(cd);
                orderToInsert.ContactDetailsId = cd.Id;
            }
        }

        private void AddAddressObje(Order orderToInsert, PlaceOrderVM vm)
        {
            Guid? founded = this._dbContext.Addresses
                .Where(a => a.AddressLine == vm.Address.AddressLine
                    && a.City == vm.Address.City
                    && a.RegionId == vm.Address.Region.Value
                    && a.ZipCode == vm.Address.ZipCode)
                .Select(v => v.Id)
                .FirstOrDefault();

            if (founded.HasValue && founded.Value != Guid.Empty)
            {
                orderToInsert.AddressId = founded.Value;
            }
            else
            {
                Address addressObj = new Address()
                {
                    Id = Guid.NewGuid(),
                    AddressLine = vm.Address.AddressLine,
                    City = vm.Address.City,
                    RegionId = vm.Address.Region.Value,
                    ZipCode = vm.Address.ZipCode

                };
                this._dbContext.Addresses.Add(addressObj);
                orderToInsert.AddressId = addressObj.Id;
            }
        }
    }
}
