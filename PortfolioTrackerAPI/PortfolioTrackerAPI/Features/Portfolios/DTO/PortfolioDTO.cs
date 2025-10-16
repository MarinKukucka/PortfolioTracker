namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public class PortfolioDTO
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required bool IsDefault { get; set; }

        public required decimal Value { get; set; }
    }
}
