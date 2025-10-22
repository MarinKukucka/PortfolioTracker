using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Shared;
using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Domain
{
    public class Transaction : BaseEntity
    {
        public required TransactionType Type { get; set; }

        [Precision(28, 8)]
        public required decimal Quantity { get; set; }

        [Precision(18, 4)]
        public required decimal UnitPrice { get; set; }

        [Precision(18, 4)]
        public required decimal TotalPrice { get; set; }

        public required DateTime TransactionDateTime { get; set; }

        public required Guid PortfolioId { get; set; }

        public Portfolio? Portfolio { get; set; }

        public required Guid AssetId { get; set; }

        public Asset? Asset { get; set; }
    }
}
