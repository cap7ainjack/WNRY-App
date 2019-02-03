using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Models.ViewModels;

namespace WNRY.Services.Interfaces
{
    public interface IContactDetailsService
    {
        Task<bool> Insert(RegistrationViewModel model, string identityId);
    }
}
