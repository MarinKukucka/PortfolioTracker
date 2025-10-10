using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<PortfolioAssets> PortfolioAssets { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<PriceCache> PriceCaches { get; set; }

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
