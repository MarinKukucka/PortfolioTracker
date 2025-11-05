namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko
{
    public interface ICoinGeckoService
    {
        Task<List<CryptoSymbol>> GetAllCryptosAsync(CancellationToken cancellationToken = default);

        Task<decimal?> GetCurrentCryptoPriceByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
