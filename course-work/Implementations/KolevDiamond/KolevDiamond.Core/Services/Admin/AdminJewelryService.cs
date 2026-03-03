using KolevDiamond.Core.Contracts;
using KolevDiamond.Core.Contracts.InvestmentCoin;
using KolevDiamond.Core.Contracts.InvestmentDiamond;
using KolevDiamond.Core.Contracts.MetalBar;
using KolevDiamond.Core.Contracts.Necklace;
using KolevDiamond.Core.Contracts.Ring;
using KolevDiamond.Core.Models;
using static KolevDiamond.Core.Constants.JewelryConstants;

namespace KolevDiamond.Core.Services.Admin
{
    public class AdminJewelryService : IAdminJewelryServiceContract
    {
        private readonly IRingService _ringService;
        private readonly INecklaceService _necklaceService;
        private readonly IMetalBarService _metalBarService;
        private readonly IInvestmentDiamondService _investmentDiamondService;
        private readonly IInvestmentCoinService _investmentCoinService;

        public AdminJewelryService(
            IRingService ringService,
            INecklaceService necklaceService,
            IMetalBarService metalBarService,
            IInvestmentDiamondService investmentDiamondService,
            IInvestmentCoinService investmentCoinService)
        {
            _ringService = ringService;
            _necklaceService = necklaceService;
            _metalBarService = metalBarService;
            _investmentCoinService = investmentCoinService;
            _investmentDiamondService = investmentDiamondService;
        }

        public async Task<IEnumerable<ProductIndexServiceModel>> GetAllJewelry(ProductQueryModel query)
        {
            var rings = await _ringService.GetFilteredRingsAsync(
                query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale);

            var necklaces = await _necklaceService.GetFilteredNecklacesAsync(
                query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale);

            var metalBars = await _metalBarService.GetFilteredMetalBarsAsync(
                query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale);

            var investmentCoins = await _investmentCoinService.GetFilteredInvestmentCoinsAsync(
                query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale);

            var investmentDiamonds = await _investmentDiamondService.GetFilteredInvestmentDiamondsAsync(
                query.PriceFilter, query.CurrentPage, JewelryTypeItemPerPage, query.IsForSale);

            return rings.Products
                .Concat(necklaces.Products)
                .Concat(metalBars.Products)
                .Concat(investmentCoins.Products)
                .Concat(investmentDiamonds.Products);
        }
    }
}
