using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Users.DTOs;
using PortfolioTrackerAPI.Infrastructure.Context;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Users.Service
{
    public class UserService(IApplicationDbContext _context) : IUserService
    {
        public async Task CreateOrUpdateUserAsync(ClaimsPrincipal principal, UserInfo userInfo, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var email = principal.FindFirst("email")?.Value ?? principal.FindFirst(ClaimTypes.Email)?.Value ?? userInfo.Email;
            var name = principal.FindFirst("name")?.Value ?? principal.FindFirst(ClaimTypes.Name)?.Value ?? userInfo.Name;
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.AuthId == sub, cancellationToken);
            if (user is null)
            {
                user = new User
                {
                    AuthId = sub,
                    Email = email ?? string.Empty,
                    DisplayName = name ?? string.Empty,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                var updated = false;

                if(!string.IsNullOrEmpty(name) && user.DisplayName != name)
                {
                    user.DisplayName = name;
                    updated = true;
                }

                if (updated)
                {
                    _context.Users.Update(user);

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public async Task<UserDTO?> GetUserByAuthIdAsync(string authId, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.AuthId == authId, cancellationToken);
            if (user is null) return null;

            return new UserDTO
            {
                Id = user.Id,
                AuthId = user.AuthId,
                Email = user.Email,
                DisplayName = user.DisplayName
            };
        }
    }
}
