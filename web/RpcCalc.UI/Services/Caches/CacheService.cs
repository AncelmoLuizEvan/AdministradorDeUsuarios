using RpcCalc.UI.CacheServices;
using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Services.Caches
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _cacheProvider;

        public CacheService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public void ClearCache()
        {
            _cacheProvider.ClearCache("_token");
        }

        public UsuarioLogado? GetCachedToken(string cacheKey)
        {
            var usuarioLogadoCached = _cacheProvider.GetFromCache<UsuarioLogado>(cacheKey);
            if (usuarioLogadoCached is null) return usuarioLogadoCached;

            return _cacheProvider.GetFromCache<UsuarioLogado>(cacheKey);
        }
    }
}
