using Biblioteca.Domain.Services.Autor.Entities;
using Biblioteca.Domain.Services.Entidades;

namespace Biblioteca.Domain.Services.Livro.Dto
{
    public class LivroDto
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int CategoriaId { get; set; }

        public CategoriaEntity Categoria { get; set; }
        public int AutorId { get; set; }

        public AutorEntity Autor { get; set; }
        public string Descrição { get; set; }

        public int EditoraId { get; set; }
        public EditoraEntity Editora { get; set; }

        public int StatusLivroId { get; set; }
        public StatusLivroEntity StatusLivro { get; set; }
    }
}
