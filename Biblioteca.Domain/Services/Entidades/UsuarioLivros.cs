using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class UsuarioLivros
    {
        [Key]
        public int UsuarioLivrosId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}