using DAL.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Final11011.ApiServices
{
    public class ApiProductService
    {
        private readonly HttpClient _httpClient;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>(_httpClient.BaseAddress?.ToString() + "api/Product");
        }

        public async Task GetProductByIdAsync(int id)
        {
            await _httpClient.GetFromJsonAsync<Product>(_httpClient.BaseAddress?.ToString() + $"api/Product/{id}");
        }

        public async Task AddProductAsync(Product product)
        {
            await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress?.ToString() + "api/Product", product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress?.ToString() + $"api/Product/{product.ProductArticleNumber}", product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress?.ToString() + $"api/Order/{product.ProductArticleNumber}");
        }
    }
}
