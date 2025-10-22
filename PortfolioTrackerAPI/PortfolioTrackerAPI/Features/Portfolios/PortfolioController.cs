using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Portfolios.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Portfolios
{
    [Authorize]
    public class PortfolioController(IPortfolioService _portfolioService) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPortfolios(CancellationToken cancellationToken)
        {
            var portfolios = await _portfolioService.GetPortfoliosAsync(User, cancellationToken);

            return Ok(portfolios);
        }
    }
}
