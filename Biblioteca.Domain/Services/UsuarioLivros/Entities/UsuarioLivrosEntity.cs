using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class UsuarioLivrosEntity
    {
        [Key]
        public int UsuarioLivrosId { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }

        public int LivroId { get; set; }
        public LivroEntity Livro { get; set; }
    }
}