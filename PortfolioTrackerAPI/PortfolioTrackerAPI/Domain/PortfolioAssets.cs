using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Domain
{
    public class PortfolioAssets : BaseEntity
    {
        public required decimal Quantity { get; set; }

        public required Guid PortfolioId { get; set; }

        public required Guid AssetId { get; set; }
    }
}
