using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class MotivoInativacaoMapping : IEntityTypeConfiguration<MotivoInativacaoEntity>
    {
        public void Configure(EntityTypeBuilder<MotivoInativacaoEntity> builder)
        {
            builder.ToTable("MotivosInativacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("varchar(36)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.DataCriacao)
               .IsRequired()
               .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");
        }
    }
}
