using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Services.Caches
{
    public interface ICacheService
    {
        UsuarioLogado? GetCachedToken(string cacheKey);
        void ClearCache();
    }
}
