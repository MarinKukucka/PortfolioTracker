using PortfolioTrackerAPI.Features.Users.DTOs;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Users.Service
{
    public interface IUserService
    {
        Task CreateOrUpdateUserAsync(ClaimsPrincipal principal, UserInfo userInfo, CancellationToken cancellationToken = default);

        Task<UserDTO?> GetUserByAuthIdAsync(string authId, CancellationToken cancellationToken = default);
    }
}
