using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioDto PostCadastro(UsuarioEntity usuario);
        UsuarioDto PostLogin(UsuarioEntity usuario);
        UsuarioDto PostBloqueio(UsuarioEntity usuarioEntity);
        bool Allow(int idUser);
    }
}
