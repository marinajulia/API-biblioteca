using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class UsuarioLivrosConfiguration : IEntityTypeConfiguration<UsuarioLivrosEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioLivrosEntity> builder)
        {
            builder.ToTable("UsuarioLivros");
            builder.HasKey(p => p.UsuarioLivrosId);
        }
    }
}
