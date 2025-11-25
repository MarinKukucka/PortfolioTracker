using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PortfolioTrackerAPI.Domain;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<PortfolioAsset> PortfolioAssets { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<PriceCache> PriceCaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioAsset>()
                .HasKey(pa => new { pa.PortfolioId, pa.AssetId });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Database.BeginTransactionAsync();
        }
    }
}
