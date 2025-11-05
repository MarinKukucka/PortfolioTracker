using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Infrastructure.Context;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub;
using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Infrastructure.Utils
{
    public static class PriceUtils
    {
        public async static Task<decimal> FetchAssetValue(PortfolioAsset portfolioAsset, IApplicationDbContext _context, ICoinGeckoService _coingGeckoService, IFinnhubService _finnhubService, CancellationToken cancellationToken)
        {
            if (portfolioAsset.Asset?.PriceCache?.LastUpdatedAt < DateTime.UtcNow.AddMinutes(-15) || portfolioAsset.Asset is null || portfolioAsset.Asset.PriceCache is null)
            {
                var asset = portfolioAsset.Asset;

                var assetPrice = asset?.Type switch
                {
                    AssetType.CryptoCurrency => await _coingGeckoService.GetCurrentCryptoPriceByIdAsync(asset.ExternalId, cancellationToken),
                    AssetType.Stock => await _finnhubService.GetCurrentStockPriceByIdAsync(asset.ExternalId, cancellationToken),
                    _ => 0m
                } ?? throw new HttpRequestException($"Failed to retrieve price for asset with ExternalId: {asset?.ExternalId}");

                if (portfolioAsset.Asset?.PriceCache is null)
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

                return portfolioAsset.Quantity * assetPrice;
            }
            else
            {
                return portfolioAsset.Quantity * (portfolioAsset.Asset.PriceCache.Price);
            }
        }
    }
}
