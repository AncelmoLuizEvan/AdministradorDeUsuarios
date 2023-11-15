using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class PermissaoMapping : IEntityTypeConfiguration<PermissaoEntity>
    {
        public void Configure(EntityTypeBuilder<PermissaoEntity> builder)
        {
            builder.ToTable("Permissoes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("varchar(36)");

            builder.Property(p => p.PerfilId)
                .IsRequired()
                .HasColumnType("varchar(36)");

            builder.Property(p => p.Sistema)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.Acessar)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.DataCriacao)
               .IsRequired()
               .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");
        }
    }
}
