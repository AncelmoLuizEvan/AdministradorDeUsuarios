using RpcCalc.UI.Interop.Roles;

namespace RpcCalc.UI.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> ExcluirUsuarioRole(Guid idusuario, Guid idrole)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                var response = await httpClient.DeleteFromJsonAsync<bool>($"api/Usuario/{idusuario}/role/{idrole}/excluirRole");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<RoleDto>?> ObterTodos()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("API");
                return await httpClient.GetFromJsonAsync<IEnumerable<RoleDto>?>("api/Role/ObterTodos");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
