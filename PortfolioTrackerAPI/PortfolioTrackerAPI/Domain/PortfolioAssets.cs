using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Domain
{
    public class PortfolioAssets : BaseEntity
    {
        [Precision(28, 8)]
        public required decimal Quantity { get; set; }

        public required Guid PortfolioId { get; set; }

        public Portfolio? Portfolio { get; set; }

        public required Guid AssetId { get; set; }

        public Asset? Asset { get; set; }
    }
}
