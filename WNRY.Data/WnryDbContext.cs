using Microsoft.EntityFrameworkCore;

namespace WNRY.Data
{
    public class WnryDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=USER17\\SQLEXPRESS;Database=WineryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}