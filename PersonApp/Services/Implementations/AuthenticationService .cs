using Newtonsoft.Json;
using PersonApp.Core.Entities.Token;
using PersonApp.Services.Interfaces;
using System.Text;

namespace PersonApp.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var credentials = new { username, password };
            var content = new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44355/api/Authentications/login", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);

                await SecureStorage.SetAsync("jwt_token", tokenResponse.Token);

                return true;
            }

            return false;
        }
    }
}
