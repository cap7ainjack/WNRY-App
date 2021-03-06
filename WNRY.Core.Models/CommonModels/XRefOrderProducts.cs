﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WNRY.Models.CommonModels
{
    public class XRefOrderProducts
    {
        public Guid Id { get; set; }

        public Order Order {get;set;}

        public Guid OrderId { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal TotalPrice { get; set; }

        // public double TotalVolume { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
