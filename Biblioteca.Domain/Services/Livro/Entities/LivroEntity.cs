using Biblioteca.Domain.Services.Autor.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Services.Entidades
{
    public class LivroEntity
    {
        [Key]
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public AutorEntity Autor { get; set; }

        public string Descrição { get; set; }

        [ForeignKey("Editora")]
        public int EditoraId { get; set; }
        public EditoraEntity Editora { get; set; }

        [ForeignKey("StatusLivro")]
        public int StatusLivroId { get; set; }
        public StatusLivroEntity StatusLivro { get; set; }
    }
}
