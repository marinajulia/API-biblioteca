using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Services.Entidades
{
    public class UsuarioEntity
    {
        [Key]
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }

        [ForeignKey("StatusUsuario")]
        public int StatusUsuarioId { get; set; }
        public StatusUsuarioEntity StatusUsuario { get; set; }

        public string Email { get; set; }

        [ForeignKey("PerfilUsuario")]
        public int PerfilUsuarioId { get; set; }
        public PerfilUsuarioEntity PerfilUsuario{ get; set; }
    }
}
