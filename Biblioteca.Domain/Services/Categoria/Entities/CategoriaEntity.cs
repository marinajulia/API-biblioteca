using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class CategoriaEntity
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public string DescriçãoCategoria { get; set; }
    }
}
