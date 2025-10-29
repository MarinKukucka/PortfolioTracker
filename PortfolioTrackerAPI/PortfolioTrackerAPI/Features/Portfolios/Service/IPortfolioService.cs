using PortfolioTrackerAPI.Features.Portfolios.DTO;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDTO>> GetPortfoliosAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);

        Task CreatePortfolioAsync(ClaimsPrincipal principal, CreatePortfolioCommand command, CancellationToken cancellationToken = default);

        Task UpdatePortfolioAsync(UpdatePortfolioCommand command, CancellationToken cancellationToken = default);

        Task DeletePortfolioAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
