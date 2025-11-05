namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko
{
    public class CoinGeckoService(HttpClient _httpClient) : BaseApiClient(_httpClient), ICoinGeckoService
    {
        public async Task<List<CryptoSymbol>> GetAllCryptosAsync(CancellationToken cancellationToken)
        {
            return await GetAsync<List<CryptoSymbol>>("coins/list", cancellationToken) ?? [];
        }

        public async Task<decimal?> GetCurrentCryptoPriceByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var crypto = await GetAsync<CoinData>($"coins/{id}", cancellationToken);

            return crypto?.Market_data?.Current_price?.Usd;
        }
    }
}
