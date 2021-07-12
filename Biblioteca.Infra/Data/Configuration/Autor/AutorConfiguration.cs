using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biblioteca.Domain.Services.Categoria;

namespace Biblioteca.Infra.Data.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(p => p.AutorId);
            builder.Property(p => p.NomeAutor).IsRequired();
        }
    }
}
