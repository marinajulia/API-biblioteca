using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(p => p.CategoriaId);
            builder.Property(p => p.NomeCategoria).IsRequired();
            builder.Property(p => p.DescriçãoCategoria).IsRequired();
        }
    }
}
