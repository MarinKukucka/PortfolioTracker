using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Assets.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Assets
{
    [Authorize]
    public class AssetController(IAssetService _assetService) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAssetsAsync(CancellationToken cancellationToken)
        {
            var assets = await _assetService.GetAllAssetsAsync(cancellationToken);

            return Ok(assets);
        }
    }
}
