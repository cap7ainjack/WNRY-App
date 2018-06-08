
using Microsoft.AspNetCore.Identity;

namespace WNRY.Models.IdentityModels
{
    public class AppUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? FacebookId { get; set; }

        public string Phone { get; set; }

    }
}
