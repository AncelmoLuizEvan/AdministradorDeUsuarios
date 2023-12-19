using RpcCalc.UI.Interop.Roles;
using RpcCalc.UI.Services.Caches;

namespace RpcCalc.UI.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICacheService _cacheService;

        public RoleService(IHttpClientFactory httpClientFactory, ICacheService cacheService)
        {
            _httpClientFactory = httpClientFactory;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<RoleDto>?> ObterTodos()
        {
            try
            {
                var usuarioLogadoCached = _cacheService.GetCachedToken("_token");
                var httpClient = _httpClientFactory.CreateClient("API");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", usuarioLogadoCached!.Token);
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
