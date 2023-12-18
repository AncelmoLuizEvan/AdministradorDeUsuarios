namespace RpcCalc.UI.Services.Caches
{
    public interface ICacheService
    {
        string GetCachedToken(string cacheKey);
        void ClearCache();
    }
}
