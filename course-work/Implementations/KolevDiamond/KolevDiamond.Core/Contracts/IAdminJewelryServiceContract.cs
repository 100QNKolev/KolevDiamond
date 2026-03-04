using KolevDiamond.Core.Models;

namespace KolevDiamond.Core.Contracts
{
    public interface IAdminJewelryServiceContract
    {
        Task<ProductQueryModel> GetAllJewelry(ProductQueryModel query);
    }
}
