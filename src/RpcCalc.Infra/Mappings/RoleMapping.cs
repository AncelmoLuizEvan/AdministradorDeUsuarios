using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("varchar(36)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.DataCriacao)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasData(PopularDadosIniciais());
        }

        private IList<RoleEntity> PopularDadosIniciais()
        {
            return new List<RoleEntity>
            {
                new RoleEntity("Admin","Administrador"),
                new RoleEntity("Cliente", "Cliente RpcCalc")
            };
        }
    }
}
