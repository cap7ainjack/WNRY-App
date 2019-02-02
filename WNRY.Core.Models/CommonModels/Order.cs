using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.IdentityModels;

namespace WNRY.Models.CommonModels
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public DateTime? ShippingDate { get; set; }

        public bool Completed { get; set; }

        [Required]
        public Address Address { get; set; }

        public Guid AddressId { get; set; }

        [Required]
        public ContactDetails ContactDetails { get; set; }

        public Guid ContactDetailsId { get; set; }

        public AppUser User { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<XRefOrderProducts> OrderedProducts { get; set; }
    }
}
