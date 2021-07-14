using Biblioteca.Domain.Services.Autor.Entities;
using Biblioteca.Domain.Services.Categoria;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Services.Entidades
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [MaxLength(100, ErrorMessage = "Este compo deve conter entre 1 e 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 100 caracteres")]
        public string Titulo { get; set; }

        [Column(TypeName = "char(13)")]
        public string ISBN { get; set; }

        public int CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; }

        public int AutorId { get; set; }

        public AutorEntity Autor { get; set; }

        public string Descrição { get; set; }

        public int EditoraId { get; set; }
        public EditoraEntity Editora { get; set; }

        public int StatusLivroId { get; set; }
        public StatusLivro StatusLivro { get; set; }
    }
}
