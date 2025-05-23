using GymDev.Client.Pages;
using GymDev.Shared.Modelos;
using System.Net.Http.Json;
namespace GymDev.Client.Servicios
{
    public class EntrenadorServicio
    {
        private readonly HttpClient _httpClient;
        public EntrenadorServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Entrenador>> ObtenerEntrenadores()
        {
            var response = await _httpClient.GetAsync("api/Entrenadors");
            if (response.IsSuccessStatusCode)
            {
                var entrenadores = await response.Content.ReadFromJsonAsync<List<Entrenador>>();
                return entrenadores ?? new List<Entrenador>();
            }
            else
            {
                throw new HttpRequestException($"Error fetching entrenadores: {response.StatusCode}");
            }
        }
        public async Task AgregarEntrenador(Entrenador entrenador)
        {
            await _httpClient.PostAsJsonAsync("api/Entrenadors", entrenador);
        }
        public async Task ActualizarEntrenador(Entrenador entrenador)
        {
            await _httpClient.PutAsJsonAsync($"api/Entrenadors/{entrenador.Id}", entrenador);
        }
        public async Task EliminarEntrenador(int id)
        {
            await _httpClient.DeleteAsync($"api/Entrenadors/{id}");
        }
        public async Task<Entrenador> ObtenerEntrenadorPorId(int id)
        {
            var response = await _httpClient.GetAsync($"api/Entrenadors/{id}");
            if (response.IsSuccessStatusCode)
            {
                var entrenador = await response.Content.ReadFromJsonAsync<Entrenador>();
                return entrenador;
            }
            else
            {
                throw new HttpRequestException($"Error fetching entrenador: {response.StatusCode}");
            }









        }
    }
}

