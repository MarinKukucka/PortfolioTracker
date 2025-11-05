using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Portfolios.DTO;
using PortfolioTrackerAPI.Infrastructure.Context;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub;
using PortfolioTrackerAPI.Infrastructure.Utils;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Portfolios.Service
{
    public class PortfolioService(
        IApplicationDbContext _context, 
        ICoinGeckoService _coingGeckoService, 
        IFinnhubService _finnhubService) : IPortfolioService
    {
        public async Task<List<PortfolioDTO>> GetPortfoliosAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var portfolios = await _context.Portfolios
                .Include(p => p.PortfolioAssets)
                .Include(p => p.Assets)
                    .ThenInclude(a => a.PriceCache)
                .Where(p => p.UserId == sub)
                .ToListAsync(cancellationToken);

            var portfolioDTOs = new List<PortfolioDTO>();

            foreach (var portfolio in portfolios)
            {
                portfolioDTOs.Add(new PortfolioDTO
                {
                    Id = portfolio.Id,
                    Name = portfolio.Name,
                    IsDefault = portfolio.IsDefault
                });
            }

            return portfolioDTOs;
        }

        public async Task<PortfolioDTO> GetPortfolioByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var portfolio = await _context.Portfolios
                .Include(p => p.PortfolioAssets)
                .Include(p => p.Assets)
                    .ThenInclude(a => a.PriceCache)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new ArgumentException("Portfolio not found.");

            var portfolioValue = await PortfolioCalculator.CalculatePortolioValue(portfolio, _context, _coingGeckoService, _finnhubService, cancellationToken);

            return new PortfolioDTO
            {
                Id = portfolio.Id,
                Name = portfolio.Name,
                IsDefault = portfolio.IsDefault,
                Value = portfolioValue
            };
        }

        public async Task CreatePortfolioAsync(ClaimsPrincipal principal, CreatePortfolioCommand command, CancellationToken cancellationToken = default)
        {
            var sub = principal.FindFirst("sub")?.Value ?? principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(sub)) throw new ArgumentException("Authenticated user has no sub claim.");

            var userHasPortfolios = await _context.Portfolios
                .Where(p => p.UserId == sub)
                .AnyAsync(cancellationToken);

            var portfolio = new Portfolio
            {
                Name = command.Name,
                Description = command.Description,
                IsDefault = !userHasPortfolios,
                CreatedAt = DateTime.UtcNow,
                UserId = sub,
            };

            _context.Portfolios.Add(portfolio);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdatePortfolioAsync(UpdatePortfolioCommand command, CancellationToken cancellationToken = default)
        {
            await _context.Portfolios
                .Where(p => p.Id == command.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.Name, command.Name)
                    .SetProperty(p => p.Description, command.Description), cancellationToken);
        }

        public async Task DeletePortfolioAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            await _context.Portfolios
                .Where(p => p.Id == Id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
