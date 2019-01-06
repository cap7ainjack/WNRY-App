using FluentValidation.Attributes;
using WNRY.Models.ViewModels.Validations;

namespace WNRY.Models.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}