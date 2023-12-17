using Blazored.LocalStorage;
using RpcCalc.UI.Auth;
using RpcCalc.UI.Interop.Authentication;
using System.Text.Json;

namespace RpcCalc.UI.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthProvider _authProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(IHttpClientFactory httpClientFactory,
            AuthProvider authProvider,
            ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _authProvider = authProvider;
            _localStorageService = localStorageService;
        }


        public async Task<UsuarioLogado> Login(LoginViewModel viewModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync($"api/Authentication/login", viewModel);

                UsuarioLogado? usuarioLogado = new UsuarioLogado();

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    usuarioLogado = await JsonSerializer.DeserializeAsync<UsuarioLogado>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    await _localStorageService.SetItemAsync("authToken", usuarioLogado!.Token);
                    ((AuthProvider)_authProvider).UsuarioAutenticado(usuarioLogado!.Usuario!.Email);
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", usuarioLogado.Token);
                }

                return usuarioLogado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((AuthProvider)_authProvider).DesautenciarUsuario();
        }
    }
}
