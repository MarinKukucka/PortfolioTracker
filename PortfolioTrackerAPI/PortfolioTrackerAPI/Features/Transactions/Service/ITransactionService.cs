using PortfolioTrackerAPI.Features.Transactions.DTO;

namespace PortfolioTrackerAPI.Features.Transactions.Service
{
    public interface ITransactionService
    {
        Task<List<TransactionDTO>> GetTransactionsByPortfolioAndAssetIdAsync(Guid portfolioId, Guid assetId, CancellationToken cancellationToken = default);

        Task AddTransactionAsync(AddTransactionCommand command, CancellationToken cancellationToken = default);
    }
}
