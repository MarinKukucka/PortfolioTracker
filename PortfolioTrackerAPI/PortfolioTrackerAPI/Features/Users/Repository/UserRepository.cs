using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Infrastructure.Context;

namespace PortfolioTrackerAPI.Features.Users.Repository
{
    public class UserRepository(IApplicationDbContext _context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
