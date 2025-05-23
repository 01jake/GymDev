using GymDev.Shared.Modelos;
using System.Net.Http.Json;
namespace GymDev.Client.Servicios
{
    public class ClienteServicio
    {
        private readonly HttpClient _httpClient;
        public ClienteServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> ObtenerPersonaje()
        {
            var response = await _httpClient.GetAsync("api/Clientes");
            if (response.IsSuccessStatusCode)
            {
                var clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();
                return clientes ?? new List<Cliente>();
            }
            else
            {

                throw new HttpRequestException($"Error fetching personajes: {response.StatusCode}");
            }
        }
        public async Task AgregarCliente(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("api/Clientes", cliente);
        }
        public async Task ActualizarCliente(Cliente cliente)
        {
            await _httpClient.PutAsJsonAsync($"api/Clientes/{cliente.Id}", cliente);
        }
    
        public async Task EliminarCliente(int id)
        {
            await _httpClient.DeleteAsync($"api/Clientes/{id}");
        }
        public async Task<List<Cliente>> ObtenerCliente()
        {
            var response = await _httpClient.GetAsync("api/Clientes");
            if (response.IsSuccessStatusCode)
            {
                var clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();
                return clientes ?? new List<Cliente>();
            }
            else
            {

                throw new HttpRequestException($"Error fetching personajes: {response.StatusCode}");
            }
        }
      






    }
}
