using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.ViewModels.Common;

namespace WNRY.Models.ViewModels
{
    public class AddressViewModel
    {
        public string AddressLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public TextAndValueBox Region { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
