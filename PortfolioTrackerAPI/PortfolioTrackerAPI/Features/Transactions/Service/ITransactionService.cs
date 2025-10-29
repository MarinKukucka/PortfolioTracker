using PortfolioTrackerAPI.Features.Transactions.DTO;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Transactions.Service
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(ClaimsPrincipal principal, AddTransactionCommand command, CancellationToken cancellationToken = default);
    }
}
