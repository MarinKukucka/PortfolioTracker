using PortfolioTrackerAPI.Shared;
using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Domain
{
    public class Transaction : BaseEntity
    {
        public required TransactionType Type { get; set; }

        public required decimal Quantity { get; set; }

        public required decimal UnitPrice { get; set; }

        public required decimal TotalPrice { get; set; }

        public required DateTime TransactionDateTime { get; set; }

        public required Guid PortfolioId { get; set; }

        public Portfolio? Portfolio { get; set; }

        public required Guid AssetId { get; set; }

        public Asset? Asset { get; set; }
    }
}
