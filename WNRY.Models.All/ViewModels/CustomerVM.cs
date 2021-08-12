using System;
using System.Collections.Generic;
using System.Text;

namespace WNRY.Models.ViewModels
{
    public class CustomerVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? FacebookId { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }
    }
}
