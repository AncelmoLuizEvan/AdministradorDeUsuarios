using RpcCalc.UI.CacheServices;

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

        public string GetCachedToken(string cacheKey)
        {
            var tokenCached = _cacheProvider.GetFromCache<string>(cacheKey);
            if (!String.IsNullOrEmpty(tokenCached)) return tokenCached;

            return _cacheProvider.GetFromCache<string>(cacheKey);
        }
    }
}
