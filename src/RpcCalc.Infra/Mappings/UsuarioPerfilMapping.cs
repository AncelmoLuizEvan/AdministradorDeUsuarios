using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class UsuarioPerfilMapping : IEntityTypeConfiguration<UsuarioPerfilEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfilEntity> builder)
        {
            builder.ToTable("UsuariosPerfis");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("varchar(36)");

            builder.Property(p => p.UsuarioId)
               .IsRequired()
               .HasColumnType("varchar(36)");

            builder.Property(p => p.PerfilId)
               .IsRequired()
               .HasColumnType("varchar(36)");

            builder.Property(p => p.DataInicio)
             .IsRequired()
             .HasColumnType("DATETIME");

            builder.Property(p => p.DataFinal)
                .IsRequired(false)
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataCriacao)
               .IsRequired()
               .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");
        }
    }
}
