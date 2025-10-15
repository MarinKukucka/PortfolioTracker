using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Users.DTOs;
using PortfolioTrackerAPI.Infrastructure.Context;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Users.Service
{
    public class UserService(IApplicationDbContext _context) : IUserService
    {
        public async Task<UserDTO> GetOrCreateUserAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var email = principal.FindFirst("email")?.Value;
            var name = principal.FindFirst("name")?.Value;
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == sub, cancellationToken);
            if (user is null)
            {
                user = new User
                {
                    Id = sub,
                    Email = email ?? string.Empty,
                    DisplayName = name ?? string.Empty,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                
                await _context.SaveChangesAsync(cancellationToken);

                return new UserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName
                };
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

                return new UserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    DisplayName = user.DisplayName
                };
            }
        }

        public async Task<UserDTO?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (user is null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName
            };
        }
    }
}
