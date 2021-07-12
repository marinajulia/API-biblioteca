using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class StatusLivroConfiguracao : IEntityTypeConfiguration<StatusLivro>
    {
        public void Configure(EntityTypeBuilder<StatusLivro> builder)
        {
            builder.ToTable("StatusLivro");
            builder.HasKey(p => p.StatusLivroId);
            builder.Property(p => p.NomeStatus).IsRequired();
        }
    }
}
