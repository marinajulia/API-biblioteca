using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Domain.Services.Entidades
{
    public class UsuarioLivros
    {
        [Key]
        public int UsuarioLivrosId { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int LivroId { get; set; }
        public Livros Livro { get; set; }
    }
}
