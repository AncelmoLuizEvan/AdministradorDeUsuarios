using RpcCalc.APP.Interop.Permissoes;

namespace RpcCalc.APP.Services.Permissoes
{
    public class PermissaoService : IPermissaoService
    {
        public HttpClient _httpClient;

        public PermissaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PermissaoDto?> Capturar(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PermissaoDto>($"api/permissao/{id}");
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
                var response = await _httpClient.DeleteFromJsonAsync<bool>($"api/permissao/excluir/{id}");

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
                return await _httpClient.GetFromJsonAsync<IEnumerable<PermissaoDto>?>("api/permissao/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
