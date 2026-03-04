using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentDiamond;

namespace KolevDiamond.Web.Services
{
    public class InvestmentDiamondApiService
    {
        private readonly HttpClient _http;

        public InvestmentDiamondApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllAsync(decimal? priceFilter, int currentPage, int productsPerPage)
        {
            var url = $"api/investmentdiamonds?currentPage={currentPage}&productsPerPage={productsPerPage}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<InvestmentDiamondDetailsServiceModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<InvestmentDiamondDetailsServiceModel>($"api/investmentdiamonds/{id}");
        }
    }
}
