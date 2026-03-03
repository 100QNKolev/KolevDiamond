using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Ring;

namespace KolevDiamond.Core.Contracts.Ring
{
    public interface IRingService : IService<RingModel>
    {
        Task<KolevDiamond.Infrastructure.Data.Models.Ring?> GetByIdAsync(int id);
        Task<KolevDiamond.Infrastructure.Data.Models.Ring?> GetByIdAsyncAsTracking(int id);
        Task<ProductQueryModel> GetFilteredRingsAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
