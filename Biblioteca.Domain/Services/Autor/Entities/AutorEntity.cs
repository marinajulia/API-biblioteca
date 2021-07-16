using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Autor.Entities
{
    public class AutorEntity
    {
        [Key]
        public int AutorId { get; set; }
        public string NomeAutor { get; set; }
    }
}
