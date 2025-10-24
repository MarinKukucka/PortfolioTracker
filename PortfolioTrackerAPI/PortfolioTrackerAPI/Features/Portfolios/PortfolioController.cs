using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Portfolios.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio([FromBody] CreatePortfolioCommand command, CancellationToken cancellationToken)
        {
            await _portfolioService.CreatePortfolioAsync(command, cancellationToken);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolio([FromBody] UpdatePortfolioCommand command, CancellationToken cancellationToken)
        {
            await _portfolioService.UpdatePortfolioAsync(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(Guid id, CancellationToken cancellationToken)
        {
            await _portfolioService.DeletePortfolioAsync(id, cancellationToken);

            return Ok();
        }
    }
}
