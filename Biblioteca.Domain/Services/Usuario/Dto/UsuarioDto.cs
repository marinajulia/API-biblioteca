using Biblioteca.Domain.Services.Entidades;

namespace Biblioteca.Domain.Services.Usuario.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public int StatusUsuarioId { get; set; }

        public StatusUsuarioEntity StatusUsuario { get; set; }

        public string Email { get; set; }

        public int PerfilUsuarioId { get; set; }
        public PerfilUsuarioEntity PerfilUsuario { get; set; }
    }
}
