using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Services.Entidades
{
    public class UsuarioLivrosEntity
    {
        [Key]
        public int UsuarioLivrosId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }

        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public LivroEntity Livro { get; set; }
    }
}