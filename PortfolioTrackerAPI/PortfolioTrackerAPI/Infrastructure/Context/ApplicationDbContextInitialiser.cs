using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortfolioTrackerAPI.Domain;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.CoinGecko;
using PortfolioTrackerAPI.Infrastructure.Services.ApiServices.Finnhub;
using PortfolioTrackerAPI.Shared.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PortfolioTrackerAPI.Infrastructure.Context
{
    public partial class ApplicationDbContextInitialiser(
        ApplicationDbContext context,
        IFinnhubService _finnhubService,
        ICoinGeckoService _coinGeckoService)
    {

        public async Task InitialiseAsync(CancellationToken cancellationToken = default)
        {
            await context.Database.MigrateAsync(cancellationToken);
        }

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            await TrySeedAsync(cancellationToken);
        }

        private async Task TrySeedAsync(CancellationToken cancellationToken = default)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await SeedStocksAsync(cancellationToken);
                await SeedCryptosAsync(cancellationToken);
                SeedPreciousMetals();

                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        #region Seeds

        protected async Task SeedStocksAsync(CancellationToken cancellationToken = default)
        {
            if(!context.Assets.IgnoreQueryFilters().Any(a => a.Type == AssetType.Stock))
            {
                var stocks = await _finnhubService.GetAllStocksByExchangeAsync("US", cancellationToken);

                foreach(var stock in stocks)
                {
                    context.Assets.Add(new Asset
                    {
                        Name = stock.Description,
                        Symbol = stock.DisplaySymbol,
                        Type = AssetType.Stock,
                        ExternalId = stock.Symbol
                    });
                }
            }
        }

        protected async Task SeedCryptosAsync(CancellationToken cancellationToken = default)
        {
            if(!context.Assets.IgnoreQueryFilters().Any(a => a.Type == AssetType.CryptoCurrency))
            {
                var cryptos = await _coinGeckoService.GetAllCryptosAsync(cancellationToken);

                foreach(var crypto in cryptos)
                {
                    context.Assets.Add(new Asset
                    {
                        Name = crypto.Name,
                        Symbol = crypto.Symbol.ToUpper(),
                        Type = AssetType.CryptoCurrency,
                        ExternalId = crypto.Id
                    });
                }
            }
        }

        protected void SeedPreciousMetals()
        {
            if(!context.Assets.IgnoreQueryFilters().Any(a => a.Type == AssetType.PreciousMetal))
            {
                context.Assets.AddRange(
                [
                    new Asset
                    {
                        Name = "Gold",
                        Symbol = "XAU",
                        Type = AssetType.PreciousMetal,
                        ExternalId = "XAU"
                    },
                    new Asset
                    {
                        Name = "Silver",
                        Symbol = "XAG",
                        Type = AssetType.PreciousMetal,
                        ExternalId = "XAG"
                    },
                    new Asset
                    {
                        Name = "Platinum",
                        Symbol = "XPT",
                        Type = AssetType.PreciousMetal,
                        ExternalId = "XPT"
                    },
                    new Asset
                    {
                        Name = "Palladium",
                        Symbol = "XPD",
                        Type = AssetType.PreciousMetal,
                        ExternalId = "XPD"
                    }
                ]);
            }
        }

        #endregion
    }
}
