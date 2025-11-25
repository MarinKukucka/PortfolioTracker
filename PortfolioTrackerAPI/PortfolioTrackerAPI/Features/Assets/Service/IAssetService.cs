using PortfolioTrackerAPI.Features.Assets.DTO;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Assets.Service
{
    public interface IAssetService
    {
        Task<List<OptionDTO>> GetAssetOptionsAsync(CancellationToken cancellationToken = default);
    }
}
