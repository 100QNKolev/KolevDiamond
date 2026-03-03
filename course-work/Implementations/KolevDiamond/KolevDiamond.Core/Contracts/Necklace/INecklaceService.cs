using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Necklace;

namespace KolevDiamond.Core.Contracts.Necklace
{
    public interface INecklaceService : IService<NecklaceModel>
    {
        Task<KolevDiamond.Infrastructure.Data.Models.Necklace?> GetByIdAsync(int id);
        Task<KolevDiamond.Infrastructure.Data.Models.Necklace?> GetByIdAsyncAsTracking(int id);
        Task<ProductQueryModel> GetFilteredNecklacesAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale = true);
    }
}
