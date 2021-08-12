using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IContactDetailsRepository: IDisposable
    {
        ValueTask<EntityEntry<ContactDetails>> AddAsync(ContactDetails entity);

        void Update(ContactDetails entity);

        Task<int> SaveChangesAsync();
    }
}
