using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Domain
{
    public class Portfolio : BaseEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required bool IsDefault { get; set; }

        public required DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public required string UserId { get; set; }

        public User? User { get; set; }


        public List<Asset> Assets { get; set; } = [];

        public List<PortfolioAsset> PortfolioAssets { get; set; } = [];

        public List<Transaction> Transactions { get; set; } = [];
    }
}
