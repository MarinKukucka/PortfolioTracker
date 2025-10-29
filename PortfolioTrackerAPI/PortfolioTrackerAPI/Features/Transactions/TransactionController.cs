using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Transactions.DTO;
using PortfolioTrackerAPI.Features.Transactions.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Transactions
{
    public class TransactionController(ITransactionService _transactionService) : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionCommand command, CancellationToken cancellationToken)
        {
            await _transactionService.AddTransactionAsync(User, command, cancellationToken);

            return Ok();
        }
    }
}
