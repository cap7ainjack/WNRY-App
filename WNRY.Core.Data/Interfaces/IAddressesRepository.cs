using System.Threading.Tasks;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IAddressesRepository
    {
        Task AddAsync(Address entity);

        Task<int> SaveChangesAsync();

        void Update(Address entity);

    }
}
