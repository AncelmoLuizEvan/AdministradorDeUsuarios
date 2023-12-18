using Microsoft.EntityFrameworkCore;
using RpcCalc.Infra.Context;

namespace RpcCalc.API.Configuration
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
