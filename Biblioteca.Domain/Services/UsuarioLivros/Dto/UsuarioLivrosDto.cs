using Biblioteca.Domain.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

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
