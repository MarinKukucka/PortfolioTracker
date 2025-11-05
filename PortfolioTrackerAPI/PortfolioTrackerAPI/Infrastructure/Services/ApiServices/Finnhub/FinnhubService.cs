namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub
{
    public class FinnhubService(HttpClient httpClient) : BaseApiClient(httpClient), IFinnhubService
    {
        public async Task<List<StockSymbol>> GetAllStocksByExchangeAsync(string exchangeCode, CancellationToken cancellationToken)
        {
            return await GetAsync<List<StockSymbol>>($"stock/symbol?exchange={exchangeCode}", cancellationToken) ?? [];
        }

        public async Task<decimal?> GetCurrentStockPriceByIdAsync(string id, CancellationToken cancellationToken)
        {
            var stock = await GetAsync<StockPrice>($"quote?symbol={id}", cancellationToken);

            return stock?.C;
        }
    }
}
