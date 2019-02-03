using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        public ContactDetailsRepository(WnryDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<ContactDetails>();
        }

        protected DbSet<ContactDetails> DbSet { get; set; }

        protected WnryDbContext Context { get; set; }
        
        public virtual Task AddAsync(ContactDetails entity) => this.DbSet.AddAsync(entity);

        public virtual void Update(ContactDetails entity)
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
