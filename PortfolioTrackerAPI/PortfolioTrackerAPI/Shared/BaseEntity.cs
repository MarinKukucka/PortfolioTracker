namespace PortfolioTrackerAPI.Shared
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
