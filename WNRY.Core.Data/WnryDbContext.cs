using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WNRY.Models.IdentityModels;

namespace WNRY.Core.Data
{
    public class WnryDbContext : IdentityDbContext
    {
        public WnryDbContext(DbContextOptions<WnryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}