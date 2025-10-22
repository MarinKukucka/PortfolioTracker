namespace PortfolioTrackerAPI.Features.Users.DTOs
{
    public record UserInfo
    {
        public required string Email { get; set; }

        public required string Name { get; set; }
    }
}
