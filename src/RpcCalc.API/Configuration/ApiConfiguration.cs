using Microsoft.Net.Http.Headers;

namespace RpcCalc.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void UseApiCorsConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            var urlCorsHTTPS = configuration["Configuration:UrlCorsHTTPS"];
            var urlCorsHTTP = configuration["Configuration:UrlCorsHTTP"];

            app.UseCors(policy =>
            policy.WithOrigins(urlCorsHTTPS, urlCorsHTTP)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithHeaders(HeaderNames.ContentType));
        }
    }
}
