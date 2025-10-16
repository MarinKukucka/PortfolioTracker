using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Features.Assets.DTO;
using PortfolioTrackerAPI.Infrastructure.Context;

namespace PortfolioTrackerAPI.Features.Assets.Service
{
    public class AssetService(IApplicationDbContext _context) : IAssetService
    {
        public async Task<List<AssetDTO>> GetAllAssetsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Assets.Take(10).Select(a => new AssetDTO
            {
                Id = a.Id,
                Name = a.Name,
                Symbol = a.Symbol,
                Type = a.Type
            }).ToListAsync(cancellationToken);
        }
    }
}
