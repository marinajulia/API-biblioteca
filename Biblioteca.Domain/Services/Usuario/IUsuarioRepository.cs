using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioRepository
    {
        UsuarioDto PostCadastro(UsuarioEntity usuario);
        UsuarioDto GetUser(string username, string password);
    }
}
