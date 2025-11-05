namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub
{
    public interface IFinnhubService
    {
        Task<List<StockSymbol>> GetAllStocksByExchangeAsync(string exchangeCode, CancellationToken cancellationToken);

        Task<decimal?> GetCurrentStockPriceByIdAsync(string id, CancellationToken cancellationToken);
    }
}
