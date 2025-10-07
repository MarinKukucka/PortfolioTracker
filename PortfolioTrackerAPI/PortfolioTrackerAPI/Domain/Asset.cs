using PortfolioTrackerAPI.Shared;
using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Domain
{
    public class Asset : BaseEntity
    {
        public required string Name { get; set; }

        public required string Symbol { get; set; }

        public required AssetType Type { get; set; }


        public List<Portfolio> Portfolios { get; set; } = [];

        public List<PortfolioAssets> PortfolioAssets { get; set; } = [];

        public List<Transaction> Transactions { get; set; } = [];

        public PriceCache? PriceCache { get; set; }
    }
}
