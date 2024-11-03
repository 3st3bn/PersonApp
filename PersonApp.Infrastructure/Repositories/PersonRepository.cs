using PersonApp.Core.Entities.Api;
using PersonApp.Infrastructure.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PersonApp.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HttpClient _httpClient;

        public PersonRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Result>> GetPersonsAsync(string url, int limit = 10)
        {
            var personsResponse = new List<Result>();
            try
            {
                // Obtener el token desde SecureStorage
                var token = await SecureStorage.GetAsync("jwt_token");

                if (token == null)
                {
                    throw new Exception("No se encontró el token. Inicia sesión primero.");
                }

                // Añadir el token al encabezado de autorización
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var personResponse = JsonConvert.DeserializeObject<List<Result>>(jsonString);

                    if (personResponse != null)
                    {
                        personsResponse = personResponse.ToList();
                    }
                }
                else
                {
                    throw new Exception("Error al consumir la API");
                }

                return personsResponse.Take(limit).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el servidor: " + ex.Message);
            }
        }
    }
}
