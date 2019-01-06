using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WNRY.Models.CommonModels
{
    public class Region
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Ekatte { get; set; }

        public string ShortName { get; set; }
    }
}
