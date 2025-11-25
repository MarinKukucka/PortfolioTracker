using PortfolioTrackerAPI.Shared;
using System.Text.Json.Serialization;

namespace PortfolioTrackerAPI.Features.Portfolios.DTO
{
    public class PortfolioDTO
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required bool IsDefault { get; set; }

        public decimal? Value { get; set; }

        public List<PortfolioAssetDTO>? Assets { get; set; }
    }
}
