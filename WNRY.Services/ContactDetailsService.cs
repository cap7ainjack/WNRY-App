using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.Services
{
    public class ContactDetailsService : IContactDetailsService
    {
        private readonly IContactDetailsRepository _contactDetailsRepository;
        public ContactDetailsService(IContactDetailsRepository _contactDetailsRepository)
        {
            this._contactDetailsRepository = _contactDetailsRepository;
        }
        public async Task<bool> Insert(RegistrationViewModel model, string identityId)
        {
            ContactDetails toAdd = new ContactDetails()
            {
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                IdentityId = identityId
            };

            if (model.Address != null)
            {
                this.InserAddressObj(model.Address);
            }

            await this._contactDetailsRepository.AddAsync(toAdd);
            await this._contactDetailsRepository.SaveChangesAsync();

            return true;
        }

        private void InserAddressObj(AddressViewModel address)
        {
            throw new NotImplementedException();
        }
    }
}
