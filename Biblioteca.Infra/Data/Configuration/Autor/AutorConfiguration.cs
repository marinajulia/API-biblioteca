using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biblioteca.Domain.Services.Autor.Entities;

namespace Biblioteca.Infra.Data.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<AutorEntity>
    {
        public void Configure(EntityTypeBuilder<AutorEntity> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(p => p.AutorId);
            builder.Property(p => p.NomeAutor).IsRequired();
        }
    }
}
