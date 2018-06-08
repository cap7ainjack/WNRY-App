using WNRY.Models.IdentityModels;
using WNRY.Models.ViewModels;

namespace WNRY.Services.Utils
{
    public class AccountsHelper
    {
        public static AppUser ConvertToDbObj(RegistrationViewModel viewModel)
        {
            AppUser user = new AppUser()
            {
                Email = viewModel.Email,
                PasswordHash = viewModel.Password,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                UserName = viewModel.Email,
                // locations
            };

            return user;
        }
    }
}