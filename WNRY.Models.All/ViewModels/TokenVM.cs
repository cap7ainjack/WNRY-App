using System;
using System.Collections.Generic;
using System.Text;

namespace WNRY.Models.ViewModels
{
    public class TokenVM
    {
        public string Auth_token { get; set; }

        public int Expires_in { get; set; }
    }
}
