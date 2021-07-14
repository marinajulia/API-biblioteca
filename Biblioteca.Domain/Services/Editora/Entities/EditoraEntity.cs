using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class EditoraEntity
    {
        [Key]
        public int EditoraId { get; set; }
        public string NomeEditora { get; set; }
    }
}
