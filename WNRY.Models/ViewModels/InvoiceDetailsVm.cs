using System;
using System.Collections.Generic;
using System.Text;

namespace WNRY.Models.ViewModels
{
    public class InvoiceDetailsVm
    {
        public string CompanyName { get; set; }

        public string Bulstat { get; set; } // EIK. BULSTAT Unified Identification Code (UIC)

        public string Vat { get; set; } // DDS

        public string Mol { get; set; }

        public string Address { get; set; }
    }
}
