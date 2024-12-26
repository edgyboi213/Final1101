using DAL.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Final11011.ApiServices
{
    public class ApiOrderService
    {
        private readonly HttpClient _httpClient;

        public ApiOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            
            return await _httpClient.GetFromJsonAsync<List<Order>>(_httpClient.BaseAddress?.ToString() + "api/Order");
        }

        public async Task GetOrderByIdAsync(int id)
        {
            await _httpClient.GetFromJsonAsync<Order>(_httpClient.BaseAddress?.ToString() + $"api/Order/{id}");
        }

        public async Task AddOrderAsync(Order order)
        {
            await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress?.ToString() + "api/Order", order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress?.ToString() + $"api/Order/{order.OrderId}", order);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress?.ToString() + $"api/Order/{order.OrderId}");
        }
    }
}
