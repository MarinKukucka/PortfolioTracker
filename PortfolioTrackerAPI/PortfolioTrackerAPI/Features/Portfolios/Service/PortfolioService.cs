using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Portfolios.DTO;
using PortfolioTrackerAPI.Infrastructure.Context;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public class PortfolioService(IApplicationDbContext _context) : IPortfolioService
    {
        public async Task<List<PortfolioDTO>> GetPortfoliosAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var portfolios = await _context.Portfolios
                .Include(p => p.PortfolioAssets)
                .Include(p => p.Assets)
                    .ThenInclude(a => a.PriceCache)
                .Where(p => p.UserId == sub)
                .ToListAsync(cancellationToken);

            var portfolioDTOs = new List<PortfolioDTO>();

            foreach (var portfolio in portfolios)
            {
                var portfolioValue = 0m;

                foreach(var portfolioAsset in portfolio.PortfolioAssets)
                {
                    if(portfolioAsset.Asset?.PriceCache?.LastUpdatedAt < DateTime.UtcNow.AddMinutes(-15) || portfolioAsset.Asset is null || portfolioAsset.Asset.PriceCache is null)
                    {
                        var assetPrice = 0m;// Call API to update price
                        portfolioValue += portfolioAsset.Quantity * assetPrice;

                        if(portfolioAsset.Asset?.PriceCache is null)
                        {
                            _context.PriceCaches.Add(new PriceCache
                            {
                                Price = assetPrice,
                                LastUpdatedAt = DateTime.UtcNow,
                                AssetId = portfolioAsset.AssetId
                            });

                            await _context.SaveChangesAsync(cancellationToken);
                        }
                        else
                        {
                            await _context.PriceCaches
                                .Where(p => p.AssetId == portfolioAsset.AssetId)
                                .ExecuteUpdateAsync(pc => pc.SetProperty(p => p.Price, assetPrice)
                                                            .SetProperty(p => p.LastUpdatedAt, DateTime.UtcNow), cancellationToken);
                        }
                    }
                    else
                    {
                        portfolioValue += portfolioAsset.Quantity * (portfolioAsset.Asset.PriceCache.Price);
                    }
                }

                portfolioDTOs.Add(new PortfolioDTO
                {
                    Name = portfolio.Name,
                    IsDefault = portfolio.IsDefault,
                    Value = portfolioValue
                });
            }

            return portfolioDTOs;
        }

        public async Task CreatePortfolioAsync(ClaimsPrincipal principal, CreatePortfolioCommand command, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var userHasPortfolios = await _context.Portfolios
                .Where(p => p.UserId == sub)
                .AnyAsync(cancellationToken);

            var portfolio = new Portfolio
            {
                Name = command.Name,
                Description = command.Description,
                IsDefault = !userHasPortfolios,
                CreatedAt = DateTime.UtcNow,
                UserId = sub,
            };

            _context.Portfolios.Add(portfolio);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdatePortfolioAsync(UpdatePortfolioCommand command, CancellationToken cancellationToken = default)
        {
            await _context.Portfolios
                .Where(p => p.Id == command.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.Name, command.Name)
                    .SetProperty(p => p.Description, command.Description), cancellationToken);
        }

        public async Task DeletePortfolioAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            await _context.Portfolios
                .Where(p => p.Id == Id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
