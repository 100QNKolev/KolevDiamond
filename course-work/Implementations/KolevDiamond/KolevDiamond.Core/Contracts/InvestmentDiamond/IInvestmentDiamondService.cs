using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentDiamond;

namespace KolevDiamond.Core.Contracts.InvestmentDiamond
{
    public interface IInvestmentDiamondService : IService<InvestmentDiamondModel>
    {
        Task<KolevDiamond.Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsync(int id);
        Task<KolevDiamond.Infrastructure.Data.Models.InvestmentDiamond?> GetByIdAsyncAsTracking(int id);
        Task<ProductQueryModel> GetFilteredInvestmentDiamondsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
