using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentCoin;

namespace KolevDiamond.Core.Contracts.InvestmentCoin
{
    public interface IInvestmentCoinService : IService<InvestmentCoinModel>
    {
        Task<KolevDiamond.Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsync(int id);
        Task<KolevDiamond.Infrastructure.Data.Models.InvestmentCoin?> GetByIdAsyncAsTracking(int id);
        Task<ProductQueryModel> GetFilteredInvestmentCoinsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
