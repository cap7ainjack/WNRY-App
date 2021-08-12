using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.CommonModels;

namespace WNRY.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        
        // public string Location { get; set; }

        [Required]
        public string Phone { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
