using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data
{
    public class AddressesRepository : IAddressesRepository
    {
        public AddressesRepository(WnryDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<Address>();
        }

        protected DbSet<Address> DbSet { get; set; }

        protected WnryDbContext Context { get; set; }

        public virtual ValueTask<EntityEntry<Address>> AddAsync(Address entity) => this.DbSet.AddAsync(entity);

        public virtual void Update(Address entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Dispose() => this.Context.Dispose();
    }
}
