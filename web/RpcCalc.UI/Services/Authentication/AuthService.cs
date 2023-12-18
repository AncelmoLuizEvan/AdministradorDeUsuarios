using RpcCalc.UI.Interop.Authentication;
using System.Text.Json;

namespace RpcCalc.UI.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                }

                return usuarioLogado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
