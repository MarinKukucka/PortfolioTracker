using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Infrastructure.Context;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Assets.Service
{
    public class AssetService(IApplicationDbContext _context) : IAssetService
    {
        public async Task<List<OptionDTO>> GetAssetOptionsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Assets
                .Select(a => new OptionDTO
                {
                    Name = a.Symbol,
                    Id = a.Id.ToString()
                }).ToListAsync(cancellationToken);
        }
    }
}
