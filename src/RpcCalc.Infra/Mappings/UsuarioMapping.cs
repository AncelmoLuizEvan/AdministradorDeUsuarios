using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("varchar(36)");

            builder.Property(p => p.CnpjCpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.Login)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasColumnType("varchar(45)");

            builder.Property(p => p.Email)
               .IsRequired()
               .HasColumnType("varchar(45)");

            builder.Property(p => p.Celular)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.EmailVerificado)
                .HasColumnType("int");

            builder.Property(p => p.Inativo)
                .HasColumnType("int");

            builder.Property(p => p.DataHoraAcesso)
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataHoraInclusao)
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataCriacao)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasMany(f => f.MotivoInativacaoEntities)
              .WithOne(p => p.Usuario)
              .HasForeignKey(p => p.UsuarioId);
        }
    }
}
