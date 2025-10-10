using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }

        public DbSet<Portfolio> Portfolios { get; }

        public DbSet<Asset> Assets { get; }

        public DbSet<PortfolioAssets> PortfolioAssets { get; }

        public DbSet<Transaction> Transactions { get; }

        public DbSet<PriceCache> PriceCaches { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
