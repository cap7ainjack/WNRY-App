using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IAddressesRepository
    {
        ValueTask<EntityEntry<Address>> AddAsync(Address entity);

        Task<int> SaveChangesAsync();

        void Update(Address entity);

    }
}
