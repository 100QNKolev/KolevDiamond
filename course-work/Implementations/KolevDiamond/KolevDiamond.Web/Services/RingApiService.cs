using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Ring;

namespace KolevDiamond.Web.Services
{
    public class RingApiService
    {
        private readonly HttpClient _http;

        public RingApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllAsync(decimal? priceFilter, int currentPage, int productsPerPage)
        {
            var url = $"api/rings?currentPage={currentPage}&productsPerPage={productsPerPage}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<RingDetailsServiceModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<RingDetailsServiceModel>($"api/rings/{id}");
        }
    }
}
