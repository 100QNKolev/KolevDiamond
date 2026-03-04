using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.InvestmentCoin;

namespace KolevDiamond.Web.Services
{
    public class InvestmentCoinApiService
    {
        private readonly HttpClient _http;

        public InvestmentCoinApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllAsync(decimal? priceFilter, int currentPage, int productsPerPage)
        {
            var url = $"api/investmentcoins?currentPage={currentPage}&productsPerPage={productsPerPage}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<InvestmentCoinDetailsServiceModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<InvestmentCoinDetailsServiceModel>($"api/investmentcoins/{id}");
        }
    }
}
