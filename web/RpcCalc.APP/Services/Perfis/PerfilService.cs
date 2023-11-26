using RpcCalc.APP.Interop.Perfis;
using System.Text.Json;

namespace RpcCalc.APP.Services.Perfis
{
    public class PerfilService : IPerfilService
    {
        public HttpClient _httpClient;

        public PerfilService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PerfilDto?> Alterar(Guid id, PerfilViewModel viewModel)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/perfil/alterar/{id}", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var perfilUp = await JsonSerializer.DeserializeAsync<PerfilDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return perfilUp;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PerfilDto?> Capturar(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PerfilDto>($"api/perfil/{id}");
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
                var response = await _httpClient.DeleteFromJsonAsync<bool>($"api/perfil/excluir/{id}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PerfilDto?> Gravar(PerfilViewModel viewModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/perfil/gravar", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var perfilAdd = await JsonSerializer.DeserializeAsync<PerfilDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return perfilAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PerfilDto>?> ObterTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<PerfilDto>?>("api/perfil/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
