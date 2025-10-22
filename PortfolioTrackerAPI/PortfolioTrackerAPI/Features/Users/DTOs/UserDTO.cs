namespace PortfolioTrackerAPI.Features.Users.DTOs
{
    public class UserDTO
    {
        public required Guid Id { get; set; }

        public required string AuthId { get; set; }

        public required string Email { get; set; }

        public required string DisplayName { get; set; }
    }
}
