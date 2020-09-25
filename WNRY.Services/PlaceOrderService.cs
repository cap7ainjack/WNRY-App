using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using WNRY.Core.Data;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.Services
{
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly WnryDbContext _dbContext;
        public PlaceOrderService(WnryDbContext wnryDbContext)
        {
            _dbContext = wnryDbContext;
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

                // In case of Guest
                this.AddAddressObje(orderToInsert, vm);
                this.AddContactDetails(orderToInsert, vm);

                this.AddProductsToOrder(orderToInsert, vm);

                this._dbContext.Orders.Add(orderToInsert);
                this._dbContext.SaveChanges();

                // sent e-mail

                return true;
            }

            return false;
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
