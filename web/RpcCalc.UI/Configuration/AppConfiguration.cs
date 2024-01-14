namespace RpcCalc.UI.Configuration
{
    public static class AppConfiguration
    {
        public static void AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var urlApi = configuration["Configuration:UrlApi"];

            services.AddHttpClient("API", httpClient =>
            {
                httpClient.BaseAddress = new Uri(urlApi);
            });
        }
    }
}
