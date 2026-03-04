using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.MetalBar;

namespace KolevDiamond.Web.Services
{
    public class MetalBarApiService
    {
        private readonly HttpClient _http;

        public MetalBarApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllAsync(decimal? priceFilter, int currentPage, int productsPerPage)
        {
            var url = $"api/metalbars?currentPage={currentPage}&productsPerPage={productsPerPage}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<MetalBarDetailsServiceModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<MetalBarDetailsServiceModel>($"api/metalbars/{id}");
        }
    }
}
