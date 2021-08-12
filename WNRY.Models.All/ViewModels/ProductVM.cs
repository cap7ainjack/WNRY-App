using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Models.Enums;

namespace WNRY.Models.ViewModels
{
    public class ProductVM
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public string DisplayName { get; set; }

        public WineColor WineColor { get; set; }

        public WineKind Kind { get; set; }

        public double Size { get; set; } // liters

        public BottleKind BottleKind { get; set; }
    }
}
