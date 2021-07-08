using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca.Domain.Services.Entidades
{
    public class Livros
    {
        [Key]
        public int LivroId { get; set; }

        [MaxLength(100, ErrorMessage = "Este compo deve conter entre 1 e 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 100 caracteres")]
        public string Titulo { get; set; }

        [Column(TypeName = "char(13)")]
        public string ISBN { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        [MaxLength(1000, ErrorMessage = "Este compo deve conter entre 1 e 1000 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 1000 caracteres")]
        public string Descrição { get; set; }

        public int EditoraId { get; set; }
        public Editora Editora { get; set; }

        public int StatusLivroId { get; set; }
        public StatusLivro StatusLivro { get; set; }
    }
}
