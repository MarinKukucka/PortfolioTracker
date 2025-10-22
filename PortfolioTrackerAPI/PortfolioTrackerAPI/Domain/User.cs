using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Domain
{
    public class User : BaseEntity
    {
        public required string AuthId { get; set; }

        public required string Email { get; set; }

        public required string DisplayName { get; set; }

        public required DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


        public List<Portfolio> Portfolios { get; set; } = [];
    }
}
