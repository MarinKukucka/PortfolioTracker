using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Features.Transactions.DTO
{
    public record AddTransactionCommand
    {
        public required TransactionType Type { get; set; }

        public required decimal Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal TotalPrice { get; set; }

        public required Guid PortfolioId { get; set; }

        public required Guid AssetId { get; set; }
    }
}
