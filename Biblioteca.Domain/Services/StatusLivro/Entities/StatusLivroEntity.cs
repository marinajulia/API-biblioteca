using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class StatusLivroEntity
    {
        [Key]
        public int StatusLivroId { get; set; }
        public string NomeStatus { get; set; }
    }
}
