using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Features.Transactions.DTO
{
    public record TransactionDTO
    {
        public required Guid Id { get; set; }

        public required TransactionType Type { get; set; }

        public required decimal Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal TotalPrice { get; set; }

        public required DateTime TransactionDateTime { get; set; }
    }
}
