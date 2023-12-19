using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Services.Caches;
using System.Text.Json;

namespace RpcCalc.UI.Services.Perfis
{
    public class PerfilService : IPerfilService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheService _cacheService;

        public PerfilService(IHttpClientFactory httpClientFactory,
            ICacheService cacheService)
        {
            _httpClientFactory = httpClientFactory;
            _cacheService = cacheService;
        }

        public async Task<PerfilDto?> Alterar(Guid id, PerfilViewModel viewModel)
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PutAsJsonAsync($"api/perfil/alterar/{id}", viewModel);

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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                return await httpClient.GetFromJsonAsync<PerfilDto>($"api/perfil/{id}");
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
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/perfil/excluir/{id}");

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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                var response = await httpClient.PostAsJsonAsync("api/perfil/gravar", viewModel);

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
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
                return await httpClient.GetFromJsonAsync<IEnumerable<PerfilDto>?>("api/perfil/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
