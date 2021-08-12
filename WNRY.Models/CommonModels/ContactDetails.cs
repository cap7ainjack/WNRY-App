using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.IdentityModels;

namespace WNRY.Models.CommonModels
{
    public class ContactDetails
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public AppUser Identity { get; set; }

        public string IdentityId { get; set; }
    }
}
