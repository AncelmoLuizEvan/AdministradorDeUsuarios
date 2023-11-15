using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Infra.Context;
using RpcCalc.Infra.Repositories;
using RpcCalc.Infra.RepositoriesReadOnly;
using RpcCalc.UseCases.UsuarioUseCases;

namespace RpcCalc.API.Configuration
{
    public static class IocConfiguration
    {
        public static void AddRegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataBaseContext>();

            services.AddScoped<IMotivoInativacaoRepository, MotivoInativacaoRepository>();
            services.AddScoped<IMotivoInativacaoRepositoryReadOnly, MotivoInativacaoRepositoryReadOnly>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioRepositoryReadOnly, UsuarioRepositoryReadOnly>();

            //USE CASES
            services.AddScoped<IUsuarioCreate, UsuarioCreate>();
            services.AddScoped<IUsuarioUpdate, UsuarioUpdate>();
            services.AddScoped<IUsuarioSearch, UsuarioSearch>();
            services.AddScoped<IUsuarioDelete, UsuarioDelete>();
        }
    }
}
