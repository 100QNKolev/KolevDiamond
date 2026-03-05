using KolevDiamond.Core.Models;
using System.Net.Http.Json;

namespace KolevDiamond.Web.Services
{
    public class AdminApiService
    {
        private readonly HttpClient _http;

        public AdminApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<ProductQueryModel> GetAllJewelryAsync(decimal? priceFilter, int currentPage, int productsPerPage, bool isForSale)
        {
            var url = $"api/admin/jewelry?currentPage={currentPage}&productsPerPage={productsPerPage}&isForSale={isForSale}";
            if (priceFilter.HasValue)
                url += $"&priceFilter={priceFilter.Value}";

            return await _http.GetFromJsonAsync<ProductQueryModel>(url)
                ?? new ProductQueryModel();
        }

        public async Task<bool> DeleteAsync(int id, string productType)
        {
            var response = await _http.DeleteAsync($"api/admin/jewelry/{id}?productType={productType}");
            return response.IsSuccessStatusCode;
        }

        public async Task<T?> GetByIdAsync<T>(string productType, int id)
        {
            return await _http.GetFromJsonAsync<T>($"api/admin/jewelry/{productType}/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync<T>(string productType, T model)
        {
            return await _http.PostAsJsonAsync($"api/admin/jewelry/{productType}", model);
        }

        public async Task<HttpResponseMessage> UpdateAsync<T>(string productType, int id, T model)
        {
            return await _http.PutAsJsonAsync($"api/admin/jewelry/{productType}/{id}", model);
        }
    }
}
