using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.MetalBar;

namespace KolevDiamond.Core.Contracts.MetalBar
{
    public interface IMetalBarService : IService<MetalBarModel>
    {
        Task<KolevDiamond.Infrastructure.Data.Models.MetalBar?> GetByIdAsync(int id);
        Task<KolevDiamond.Infrastructure.Data.Models.MetalBar?> GetByIdAsyncAsTracking(int id);
        Task<ProductQueryModel> GetFilteredMetalBarsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
