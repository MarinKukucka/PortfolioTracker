using Microsoft.EntityFrameworkCore;

namespace PortfolioTrackerAPI.Domain
{
    public class PortfolioAsset
    {
        [Precision(28, 8)]
        public required decimal Quantity { get; set; }

        public required Guid PortfolioId { get; set; }

        public Portfolio? Portfolio { get; set; }

        public required Guid AssetId { get; set; }

        public Asset? Asset { get; set; }
    }
}
