namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public class UpdatePortfolioCommand
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
