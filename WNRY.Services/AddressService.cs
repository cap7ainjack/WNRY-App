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
    public class AddressService : IAddressService
    {
        private readonly IAddressesRepository _addressesRepository;
        public AddressService(IAddressesRepository _addressesRepository)
        {
            this._addressesRepository = _addressesRepository;
        }

        public async Task<bool> Insert(AddressViewModel model, string identityId)
        {
            Address toAdd = this.ConvertToEntityModel(model, identityId);

            await this._addressesRepository.AddAsync(toAdd);
            await this._addressesRepository.SaveChangesAsync();

            return true;
        }

        private Address ConvertToEntityModel(AddressViewModel model, string identityId)
        {
            Address toAdd = new Address()
            {
                RegionId = model.Region.Value,
                AddressLine = model.AddressLine,
                City = model.City,
                Country = "Bulgaria",
                ZipCode = model.ZipCode,
                IdentityId = identityId
            };

            return toAdd;
        }
    }
}
