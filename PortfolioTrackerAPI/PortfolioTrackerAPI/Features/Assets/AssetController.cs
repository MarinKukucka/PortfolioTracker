using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Assets.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Assets
{
    [Authorize]
    public class AssetController(IAssetService _assetService) : ApiController
    {
        [HttpGet("options")]
        public async Task<IActionResult> GetAssetOptions(CancellationToken cancellationToken)
        {
            var assetOptions = await _assetService.GetAssetOptionsAsync(cancellationToken);

            return Ok(assetOptions);
        }
    }
}
