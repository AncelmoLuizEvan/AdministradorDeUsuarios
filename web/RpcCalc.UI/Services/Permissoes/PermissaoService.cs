using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Services.Caches;
using System.Text.Json;

namespace RpcCalc.UI.Services.Permissoes
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheService _cacheService;

        public PermissaoService(IHttpClientFactory httpClientFactory,
            ICacheService cacheService)
        {
            _httpClientFactory = httpClientFactory;
            _cacheService = cacheService;
        }

        public async Task<PermissaoDto?> Capturar(Guid id)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
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
