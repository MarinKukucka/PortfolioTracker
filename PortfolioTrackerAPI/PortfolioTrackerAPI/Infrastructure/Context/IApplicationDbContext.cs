using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; }

        public DbSet<Portfolio> Portfolios { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
