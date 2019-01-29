using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.IdentityModels;

namespace WNRY.Models.CommonModels
{
    public class Address
    {
        // Consider Enum for Address Type -> for order, for receipt
        public Guid Id { get; set; }

        [Required]
        public string AddressLine { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        public Region Region { get; set; }

        public Guid RegionId { get; set; }

        public string Country { get; set; }

        [Required]
        [MaxLength(4)]
        public string ZipCode { get; set; }

        public AppUser User { get; set; }

        public Guid? UserId { get; set; }
    }
}
