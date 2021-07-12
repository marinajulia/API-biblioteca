using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biblioteca.Domain.Services.Categoria;

namespace Biblioteca.Infra.Data.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(p => p.AutorId);
            builder.Property(p => p.NomeAutor).IsRequired();
        }
    }
}
