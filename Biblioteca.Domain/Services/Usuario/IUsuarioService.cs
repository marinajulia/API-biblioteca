using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioDto PostCadastro(UsuarioDto usuario);
        UsuarioDto PostLogin(UsuarioEntity usuario);

    }
}
