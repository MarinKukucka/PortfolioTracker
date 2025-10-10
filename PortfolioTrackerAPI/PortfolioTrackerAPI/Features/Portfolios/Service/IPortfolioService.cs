using PortfolioTrackerAPI.Features.Portfolios.DTOs;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public interface IPortfolioService
    {
        Task<List<PortfolioDTO>> GetByUserId(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
    }
}
