using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IContactDetailsRepository: IDisposable
    {
        Task AddAsync(ContactDetails entity);

        Task<int> SaveChangesAsync();
    }
}
