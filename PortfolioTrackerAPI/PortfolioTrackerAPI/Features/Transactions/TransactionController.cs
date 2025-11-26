using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Transactions.DTO;
using PortfolioTrackerAPI.Features.Transactions.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Transactions
{
    public class TransactionController(ITransactionService _transactionService) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTransactionsByPortfolioAndAssetId([FromQuery] Guid portfolioId, [FromQuery] Guid assetId, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetTransactionsByPortfolioAndAssetIdAsync(portfolioId, assetId, cancellationToken);

            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionCommand command, CancellationToken cancellationToken)
        {
            await _transactionService.AddTransactionAsync(command, cancellationToken);

            return Ok();
        }
    }
}
