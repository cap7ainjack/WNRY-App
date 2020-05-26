namespace WNRY.Models.ViewModels
{
    public class PlaceOrderVM
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public AddressViewModel Address { get; set; }

        public InvoiceDetailsVm InvoiceDetails { get; set; }

        public bool? Invoice { get; set; }

        public string Description { get; set; }
    }
}
