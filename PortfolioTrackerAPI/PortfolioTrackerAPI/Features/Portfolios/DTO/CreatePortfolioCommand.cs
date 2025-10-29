namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public record CreatePortfolioCommand
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
