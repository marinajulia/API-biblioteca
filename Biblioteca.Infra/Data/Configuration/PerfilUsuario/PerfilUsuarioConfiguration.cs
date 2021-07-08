using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Biblioteca.Infra.Data.Configuration
{
    public class PerfilUsuarioConfiguration : IEntityTypeConfiguration<PerfilUsuario>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            builder.ToTable("PerfilUsuario");
            builder.HasKey(p => p.PerfilUsuarioId);
            builder.Property(p => p.Perfil).IsRequired();
        }
    }
}
