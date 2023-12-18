using Microsoft.Extensions.Caching.Memory;
using RpcCalc.UI.CacheServices;
using RpcCalc.UI.Interop.Authentication;
using System.Text.Json;

namespace RpcCalc.UI.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheProvider _cacheProvider;
        private const int CacheTimeInHours = 8;
        private readonly MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(CacheTimeInHours));

        public AuthService(IHttpClientFactory httpClientFactory, ICacheProvider cacheProvider)
        {
            _httpClientFactory = httpClientFactory;
            _cacheProvider = cacheProvider;
        }

        public async Task<UsuarioLogado> Login(LoginViewModel viewModel)
        {
            UsuarioLogado? usuarioLogado = new UsuarioLogado();

            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync($"api/Authentication/login", viewModel);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    usuarioLogado = await JsonSerializer.DeserializeAsync<UsuarioLogado>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    _cacheProvider.SetCache("_token", usuarioLogado!.Token, cacheEntryOptions);
                }

                return usuarioLogado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public void Logout()
        {
            _cacheProvider.ClearCache("_token");
        }
    }
}
