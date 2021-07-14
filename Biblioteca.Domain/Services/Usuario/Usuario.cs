using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Services.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [MaxLength(100, ErrorMessage = "Este compo deve conter entre 1 e 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 100 caracteres")]
        public string NomeUsuario { get; set; }

        [Column(TypeName = "char(11)")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }

        public int StatusUsuarioId { get; set; }

        public StatusUsuario StatusUsuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }

        public int PerfilUsuarioId { get; set; }
        public PerfilUsuarioEntity PerfilUsuario{ get; set; }
    }
}
