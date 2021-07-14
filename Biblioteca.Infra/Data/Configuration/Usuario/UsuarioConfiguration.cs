using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.UsuarioId);
            builder.Property(p => p.NomeUsuario).IsRequired();
            builder.Property(p => p.CPF);
            builder.Property(p => p.Senha).IsRequired();
            builder.Property(p => p.Email);
        }
    }
}
