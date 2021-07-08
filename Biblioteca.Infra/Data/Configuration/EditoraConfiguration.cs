using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Biblioteca.Infra.Data.Configuration
{
    public class EditoraConfiguration : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("Editora");
            builder.HasKey(p => p.EditoraId);
            builder.Property(p => p.NomeEditora).IsRequired();
        }
    }
}
