using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Portfolios.DTO;
using PortfolioTrackerAPI.Infrastructure.Context;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public class PortfolioService(IApplicationDbContext _context) : IPortfolioService
    {
        public async Task<List<PortfolioDTO>> GetByUserIdAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
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
    }
}
