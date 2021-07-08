using Biblioteca.Domain.Services.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infra.Data.Configuration
{
    public class StatusUsuarioConfiguration : IEntityTypeConfiguration<StatusUsuario>
    {
        public void Configure(EntityTypeBuilder<StatusUsuario> builder)
        {
            builder.ToTable("StatusUsuario");
            builder.HasKey(p => p.StatusUsuarioId);
            builder.Property(p => p.NomeStatus).IsRequired();

        }
    }
}
