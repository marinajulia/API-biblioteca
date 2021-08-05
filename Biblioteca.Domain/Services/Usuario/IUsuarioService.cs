using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        bool PostCadastro(UsuarioEntity usuario);
        UsuarioDto PostLogin(UsuarioEntity usuario);
        bool PutAlterarDados(UsuarioDto usuario);
        UsuarioDto GetById(int id);
        bool PostBloqueio(UsuarioDto usuarioDto);
        bool PostDesbloqueio(UsuarioDto usuarioDto);
        bool Allow(int idUser);
        IEnumerable<UsuarioDto> Get();
        IEnumerable<UsuarioDto> GetNome(string nome);
    }
}
