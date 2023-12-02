using RpcCalc.APP.Interop.Permissoes;

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
            throw new NotImplementedException();
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
