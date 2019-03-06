using System.Threading.Tasks;
using WNRY.Models.ViewModels;

namespace WNRY.Services.Interfaces
{
    public interface IAddressService
    {
        Task<bool> Insert(AddressViewModel model, string identityId);
    }
}
