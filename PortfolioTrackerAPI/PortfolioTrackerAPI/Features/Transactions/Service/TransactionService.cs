using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Features.Transactions.DTO;
using PortfolioTrackerAPI.Infrastructure.Context;
using PortfolioTrackerAPI.Shared.Enums;
using System.Security.Claims;

namespace PortfolioTrackerAPI.Features.Transactions.Service
{
    public class TransactionService(IApplicationDbContext _context) : ITransactionService
    {
        public async Task AddTransactionAsync(ClaimsPrincipal principal, AddTransactionCommand command, CancellationToken cancellationToken = default)
        {
            var portfolio = await _context.Portfolios
                .Where(p => p.Id == command.PortfolioId)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new ArgumentException("Portfolio not found.");

            var asset = await _context.Assets
                .Where(a => a.Id == command.AssetId)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new ArgumentException("Asset not found.");

            var portfolioAsset = portfolio.PortfolioAssets
                .Where(pa => pa.AssetId == command.AssetId)
                .FirstOrDefault();

            if (portfolioAsset is null)
            {
                portfolio.PortfolioAssets.Add(new PortfolioAsset
                {
                    Quantity = command.Quantity,
                    PortfolioId = command.PortfolioId,
                    AssetId = command.AssetId
                });
            }
            else
            {
                portfolioAsset.Quantity += command.Type == TransactionType.Buy ?
                    command.Quantity
                    : -command.Quantity;
            }

            _context.Transactions.Add(new Transaction
            {
                Type = command.Type,
                Quantity = command.Quantity,
                UnitPrice = command.UnitPrice,
                TotalPrice = command.TotalPrice,
                TransactionDateTime = DateTime.UtcNow,
                PortfolioId = command.PortfolioId,
                AssetId = command.AssetId
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
