namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko
{
    public interface ICoinGeckoService
    {
        Task<List<CryptoSymbol>> GetAllCryptosAsync(CancellationToken cancellationToken = default);
    }
}
