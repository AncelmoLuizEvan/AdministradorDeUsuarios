using RpcCalc.APP.Interop.Usuarios;
using System.Text.Json;

namespace RpcCalc.APP.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsuarioService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UsuarioDto?> Alterar(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PutAsJsonAsync($"api/Usuario/alterar/{id}", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var usuarioUp = await JsonSerializer.DeserializeAsync<UsuarioDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return usuarioUp;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<UsuarioDto?> Capturar(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<UsuarioDto>($"api/Usuario/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/Usuario/excluir/{id}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<UsuarioDto?> Gravar(UsuarioViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync("api/Usuario/gravar", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var usuarioAdd = await JsonSerializer.DeserializeAsync<UsuarioDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return usuarioAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<UsuarioDto>?> ObterTodos()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>?>("api/Usuario/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
