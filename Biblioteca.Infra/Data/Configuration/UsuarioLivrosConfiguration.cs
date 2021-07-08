using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class UsuarioLivrosConfiguration : IEntityTypeConfiguration<UsuarioLivros>
    {
        public void Configure(EntityTypeBuilder<UsuarioLivros> builder)
        {
            builder.ToTable("UsuarioLivros");
            builder.HasKey(p => p.UsuarioLivrosId);
        }
    }
}
