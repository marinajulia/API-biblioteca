using Biblioteca.Domain.Services.Entidades;

namespace Biblioteca.Domain.Services.UsuarioLivros.Dto
{
    public class UsuarioLivrosDto
    {
        public int UsuarioLivrosId { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }

        public int LivroId { get; set; }
        public LivroEntity Livro { get; set; }
    }
}
