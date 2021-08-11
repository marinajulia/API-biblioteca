using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioRepository
    {
        UsuarioEntity PostCadastro(UsuarioEntity usuario);
        IEnumerable<UsuarioEntity> Get(string nome);
        UsuarioEntity PutAlterarSenha(UsuarioEntity usuario);
        UsuarioEntity PutAlterar(UsuarioEntity usuario);
        UsuarioEntity GetUser(string username, string password);
        UsuarioEntity GetByName(string username);
        UsuarioEntity GetById(int id);
        IEnumerable<UsuarioEntity> Get();
        UsuarioEntity GetByStatus(int id);
        UsuarioEntity GetByCpf(string cpf);
        UsuarioEntity GetByEmail(string email);
        UsuarioEntity GetUserByEmail(string usuario);
        UsuarioEntity GetUserByName(string usuario);
        bool ValidaCpf(string cpf);
        UsuarioEntity Put(UsuarioEntity usuarioEntity);
        void UpdateStatus(int idUsuario, int idStatus);

    }
}
