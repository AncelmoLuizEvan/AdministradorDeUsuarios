using RpcCalc.API.Services;
using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;
using RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase;
using RpcCalc.Domain.Interfaces.UseCases.RoleUseCase;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Infra.Context;
using RpcCalc.Infra.Repositories;
using RpcCalc.Infra.RepositoriesReadOnly;
using RpcCalc.UseCases.MotivoInativacaoUseCases;
using RpcCalc.UseCases.PerfilUseCases;
using RpcCalc.UseCases.PermissaoUseCases;
using RpcCalc.UseCases.RoleUseCases;
using RpcCalc.UseCases.UsuarioUseCases;

namespace RpcCalc.API.Configuration
{
    public static class IocConfiguration
    {
        public static void AddRegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var serviceProvider = services.BuildServiceProvider();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<DataBaseContext>();
            services.AddTransient<TokenService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbSession>(s => new DbSession(connectionString));

            services.AddScoped<IMotivoInativacaoRepository, MotivoInativacaoRepository>();
            services.AddScoped<IMotivoInativacaoRepositoryReadOnly, MotivoInativacaoRepositoryReadOnly>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioRepositoryReadOnly, UsuarioRepositoryReadOnly>();
            services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            services.AddScoped<IUsuarioPerfilRepositoryReadOnly, UsuarioPerfilRepositoryReadOnly>();

            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPerfilRepositoryReadOnly, PerfilRepositoryReadOnly>();

            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IPermissaoRepositoryReadOnly, PermissaoRepositoryReadOnly>();

            services.AddScoped<IRoleRepositoryReadOnly, RoleRepositoryReadOnly>();
            services.AddScoped<IUsuarioRoleRepository, UsuarioRoleRepository>();
            services.AddScoped<IUsuarioRoleRepositoryReadOnly, UsuarioRoleRepositoryReadOnly>();

            //USE CASES
            services.AddScoped<IUsuarioCreate, UsuarioCreate>();
            services.AddScoped<IUsuarioUpdate, UsuarioUpdate>();
            services.AddScoped<IUsuarioSearch, UsuarioSearch>();
            services.AddScoped<IUsuarioDelete, UsuarioDelete>();

            services.AddScoped<IPerfilCreate, PerfilCreate>();
            services.AddScoped<IPerfilUpdate, PerfilUpdate>();
            services.AddScoped<IPerfilSearch, PerfilSearch>();
            services.AddScoped<IPerfilDelete, PerfilDelete>();

            services.AddScoped<IPermissaoCreate, PermissaoCreate>();
            services.AddScoped<IPermissaoSearch, PermissaoSearch>();
            services.AddScoped<IPermissaoDelete, PermissaoDelete>();

            services.AddScoped<IMotivoInativacaoCreate, MotivoInativacaoCreate>();
            services.AddScoped<IMotivoInativacaoSearch, MotivoInativacaoSearch>();

            services.AddScoped<IRoleSearch, RoleSearch>();
        }
    }
}
