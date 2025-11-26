namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public class PortfolioAssetDTO
    {
        public required decimal Quantity { get; set; }

        public required string AssetSymbol { get; set; }

        public required decimal Value { get; set; }

        public required Guid AssetId { get; set; }
    }
}
