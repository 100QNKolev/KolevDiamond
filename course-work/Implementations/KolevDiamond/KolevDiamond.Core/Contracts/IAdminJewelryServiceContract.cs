using KolevDiamond.Core.Models;

namespace KolevDiamond.Core.Contracts
{
    public interface IAdminJewelryServiceContract
    {
        Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query);
    }
}
