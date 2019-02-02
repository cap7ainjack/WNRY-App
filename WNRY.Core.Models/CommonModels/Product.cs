using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WNRY.Models.Enums;

namespace WNRY.Models.CommonModels
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public WineColor WineColor { get; set; }

        [Required]
        public WineKind Kind { get; set; }

        [Required]
        public double Size { get; set; } // liters

        [Required]
        public BottleKind BottleKind { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public IEnumerable<XRefOrderProducts> Orders { get; set; }
    }
}
