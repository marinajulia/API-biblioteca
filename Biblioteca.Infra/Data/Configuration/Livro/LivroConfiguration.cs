using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<LivroEntity>
    {
        public void Configure(EntityTypeBuilder<LivroEntity> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.LivroId);
            builder.Property(p => p.Titulo).IsRequired();
            builder.Property(p => p.ISBN).IsRequired();
        }
    }
}
