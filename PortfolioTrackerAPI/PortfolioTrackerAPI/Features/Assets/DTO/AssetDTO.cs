using PortfolioTrackerAPI.Shared.Enums;

namespace PortfolioTrackerAPI.Features.Assets.DTO
{
    public class AssetDTO
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Symbol { get; set; }

        public required AssetType Type { get; set; }
    }
}
