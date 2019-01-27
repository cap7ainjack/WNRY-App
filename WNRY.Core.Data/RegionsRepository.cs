using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data
{
    public class RegionsRepository : IRegionRepository
    {
        public RegionsRepository(WnryDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<Region>();
        }

        protected DbSet<Region> DbSet { get; set; }

        protected WnryDbContext Context { get; set; }

        public virtual IEnumerable<Region> All() => this.DbSet;

        public void Dispose() => this.Context.Dispose();
    }
}
