using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class StatusUsuarioEntity
    {
        [Key]
        public int StatusUsuarioId { get; set; }
        public string NomeStatus { get; set; }
    }
}
