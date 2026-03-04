using KolevDiamond.Core.Models;
using KolevDiamond.Core.Models.Necklace;

namespace KolevDiamond.Web.Services
{
    public class NecklaceApiService
    {
        private readonly HttpClient _http;

        public NecklaceApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllAsync(decimal? priceFilter, int currentPage, int productsPerPage)
        {
            var url = $"api/necklaces?currentPage={currentPage}&productsPerPage={productsPerPage}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<NecklaceDetailsServiceModel?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<NecklaceDetailsServiceModel>($"api/necklaces/{id}");
        }
    }
}
