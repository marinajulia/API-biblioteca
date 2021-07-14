using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class PerfilUsuarioEntity
    {
        [Key]
        public int PerfilUsuarioId { get; set; }
        public string Perfil { get; set; }
    }
}
