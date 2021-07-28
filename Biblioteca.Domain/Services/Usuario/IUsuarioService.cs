using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioDto PostCadastro(UsuarioEntity usuario);
        UsuarioDto PostLogin(UsuarioEntity usuario);
        UsuarioDto PostBloqueio(int id);
        bool Allow(int idUser);
    }
}
