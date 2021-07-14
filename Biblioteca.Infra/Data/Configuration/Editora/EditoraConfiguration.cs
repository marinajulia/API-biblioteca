using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Biblioteca.Infra.Data.Configuration
{
    public class EditoraConfiguration : IEntityTypeConfiguration<EditoraEntity>
    {
        public void Configure(EntityTypeBuilder<EditoraEntity> builder)
        {
            builder.ToTable("Editora");
            builder.HasKey(p => p.EditoraId);
            builder.Property(p => p.NomeEditora).IsRequired();
        }
    }
}
