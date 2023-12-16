using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;

namespace RpcCalc.Infra.Mappings
{
    public class PerfilMapping : IEntityTypeConfiguration<PerfilEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilEntity> builder)
        {
            builder.ToTable("Perfis");

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

            builder.HasMany(f => f.UsuariosPerfis)
                .WithOne(p => p.Perfil)
                .HasForeignKey(p => p.PerfilId);

            builder.HasData(PopularDadosIniciais());
        }

        private IList<PerfilEntity> PopularDadosIniciais()
        {
            return new List<PerfilEntity>
            {
                new PerfilEntity("Mensal","Acesso para testar o sistema"),
                new PerfilEntity("Semestral", "Acesso por seis meses"),
                new PerfilEntity("Anual", "Acesso por um ano"),
                new PerfilEntity("Vitalicio", "Acesso vitalício")
            };
        }
    }
}
