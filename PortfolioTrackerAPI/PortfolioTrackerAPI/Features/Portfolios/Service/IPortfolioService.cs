using PortfolioTrackerAPI.Features.Portfolios.DTO;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDTO>> GetByUserIdAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
    }
}
