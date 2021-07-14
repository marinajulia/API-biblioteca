using Biblioteca.Domain.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.Usuario.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }

        public int StatusUsuarioId { get; set; }

        public StatusUsuarioEntity StatusUsuario { get; set; }

        public string Email { get; set; }

        public int PerfilUsuarioId { get; set; }
        public PerfilUsuarioEntity PerfilUsuario { get; set; }
    }
}
