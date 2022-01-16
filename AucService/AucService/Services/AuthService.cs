using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AucService.Model;

namespace AucService.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client) => _client = client;

        public async Task<string> Register(User user)
        {
            var response = await _client.PostAsJsonAsync("http://0.0.0.0:5000/register", user);
            return await response.Content.ReadFromJsonAsync<string>();
        }

        public async Task<string> LogIn(UserRequest request)
        {
            var response = await _client.PostAsJsonAsync("http://0.0.0.0:5000/login", request);
            return await response.Content.ReadFromJsonAsync<string>();
        }
    }
}