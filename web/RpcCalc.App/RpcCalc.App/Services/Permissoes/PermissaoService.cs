using RpcCalc.APP.Interop.Permissoes;
using System.Text.Json;

namespace RpcCalc.APP.Services.Permissoes
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PermissaoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PermissaoDto?> Capturar(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<PermissaoDto>($"api/permissao/{id}");
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
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/permissao/excluir/{id}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<PermissaoDto?> Gravar(PermissaoViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync("api/permissao/gravar", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var permissaoAdd = await JsonSerializer.DeserializeAsync<PermissaoDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return permissaoAdd;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<PermissaoDto>?> ObterTodos()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<IEnumerable<PermissaoDto>?>("api/permissao/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
