namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko
{
    public class CoinGeckoService(HttpClient _httpClient) : BaseApiClient(_httpClient), ICoinGeckoService
    {
        public async Task<List<CryptoSymbol>> GetAllCryptosAsync(CancellationToken cancellationToken)
        {
            return await GetAsync<List<CryptoSymbol>>("coins/list", cancellationToken) ?? [];
        }
    }
}
