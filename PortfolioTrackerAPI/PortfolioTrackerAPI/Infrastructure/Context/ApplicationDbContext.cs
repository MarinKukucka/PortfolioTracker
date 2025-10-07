using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
