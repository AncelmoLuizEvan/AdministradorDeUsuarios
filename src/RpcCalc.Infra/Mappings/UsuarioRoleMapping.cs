using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpcCalc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpcCalc.Infra.Mappings
{
    public class UsuarioRoleMapping : IEntityTypeConfiguration<UsuarioRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioRoleEntity> builder)
        {
            builder.ToTable("UsuariosRoles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("varchar(36)");

            builder.Property(p => p.UsuarioId)
               .IsRequired()
               .HasColumnType("varchar(36)");

            builder.Property(p => p.RoleId)
               .IsRequired()
               .HasColumnType("varchar(36)");

            builder.Property(p => p.DataCriacao)
             .IsRequired()
             .HasColumnType("DATETIME");

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("DATETIME");

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.Roles)
                .HasForeignKey(p => p.UsuarioId);

            builder.HasOne(p => p.Role)
               .WithMany(p => p.Usuarios)
               .HasForeignKey(p => p.RoleId);
        }
    }
}
