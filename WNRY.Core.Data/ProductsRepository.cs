using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data
{
    public class ProductsRepository: IProductsRepository
    {
        public ProductsRepository(WnryDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<Product>();
        }

        protected DbSet<Product> DbSet { get; set; }

        protected WnryDbContext Context { get; set; }

        public virtual IEnumerable<Product> All() => this.DbSet;

        public void Dispose() => this.Context.Dispose();
    }
}
