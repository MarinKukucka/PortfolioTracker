namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub
{
    public class FinnhubService(HttpClient httpClient) : BaseApiClient(httpClient), IFinnhubService
    {
        public async Task<List<StockSymbol>> GetAllStocksByExchangeAsync(string exchangeCode, CancellationToken cancellationToken)
        {
            return await GetAsync<List<StockSymbol>>($"stock/symbol?exchange={exchangeCode}", cancellationToken) ?? [];
        }
    }
}
