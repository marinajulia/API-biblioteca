using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioDto PostCadastro(UsuarioEntity usuario);
        UsuarioDto PostLogin(UsuarioEntity usuario);
        bool PostBloqueio(UsuarioDto usuarioDto);
        bool PostDesbloqueio(UsuarioDto usuarioDto);
        bool Allow(int idUser);
    }
}
