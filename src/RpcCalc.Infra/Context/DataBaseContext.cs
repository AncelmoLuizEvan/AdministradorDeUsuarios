using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
           : base(options)
        {

        }

        public DbSet<MotivoInativacaoEntity> MotivoInativacao { get; set; }
        public DbSet<PerfilEntity>? Perfil { get; set; }
        public DbSet<PermissaoEntity>? Permissao { get; set; }
        public DbSet<UsuarioEntity>? Usuario { get; set; }
        public DbSet<UsuarioPerfilEntity>? UsuarioPerfil { get; set; }
        public DbSet<UsuarioRoleEntity>? UsuarioRole { get; set; }
        public DbSet<RoleEntity>? Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
