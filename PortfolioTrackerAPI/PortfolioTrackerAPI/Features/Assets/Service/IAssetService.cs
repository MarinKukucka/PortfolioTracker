using PortfolioTrackerAPI.Features.Assets.DTO;

namespace PortfolioTrackerAPI.Features.Assets.Service
{
    public interface IAssetService
    {
        Task<List<AssetDTO>> GetAllAssetsAsync(CancellationToken cancellationToken = default);
    }
}
