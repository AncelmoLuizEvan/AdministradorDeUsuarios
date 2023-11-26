using RpcCalc.APP.Interop.Usuarios;
using System.Text.Json;

namespace RpcCalc.APP.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        public HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioDto?> Alterar(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Usuario/alterar/{id}", viewModel);

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
                return await _httpClient.GetFromJsonAsync<UsuarioDto>($"api/Usuario/{id}");
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
                var response = await _httpClient.DeleteFromJsonAsync<bool>($"api/Usuario/excluir/{id}");

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
                var response = await _httpClient.PostAsJsonAsync("api/Usuario/gravar", viewModel);

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
                return await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>?>("api/Usuario/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
