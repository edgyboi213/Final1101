using DAL.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Final11011.ApiServices
{
    public class ApiUserService
    {
        private readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>(_httpClient.BaseAddress?.ToString() + "api/User");
        }

        public async Task GetUserByIdAsync(int id)
        {
            await _httpClient.GetFromJsonAsync<User>(_httpClient.BaseAddress?.ToString() + $"api/User/{id}");
        }

        public async Task AddUserAsync(User user)
        {
            await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress?.ToString() + "api/User", user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress?.ToString() + $"api/User/{user.UserId}", user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _httpClient.DeleteAsync(_httpClient.BaseAddress?.ToString() + $"api/User/{user.UserId}");
        }
    }
}
