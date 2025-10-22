using Microsoft.EntityFrameworkCore;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Domain
{
    public class PriceCache : BaseEntity
    {
        [Precision(18, 4)]
        public required decimal Price { get; set; }

        public required DateTime LastUpdatedAt { get; set; }

        public required Guid AssetId { get; set; }

        public Asset? Asset { get; set; }
    }
}
