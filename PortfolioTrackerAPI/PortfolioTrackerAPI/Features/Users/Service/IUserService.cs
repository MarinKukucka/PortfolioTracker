using PortfolioTrackerAPI.Features.Users.DTOs;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Users.Service
{
    public interface IUserService
    {
        Task<UserDTO> GetOrCreateUserAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);

        Task<UserDTO?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
