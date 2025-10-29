namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public class CreatePortfolioCommand
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
