namespace PortfolioTrackerAPI.Features.Portfolios.DTOs
{
    public class PortfolioDTO
    {
        public required string Name { get; set; }

        public required bool IsDefault { get; set; }

        public required decimal Value { get; set; }
    }
}
