using Biblioteca.Domain.Services.Entidades;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioRepository
    {
        UsuarioEntity PostCadastro(UsuarioEntity usuario);
        UsuarioEntity GetUser(string username, string password);
        UsuarioEntity GetByName(string username);
        UsuarioEntity GetById(int id);
        UsuarioEntity GetByCpf(string cpf);
        UsuarioEntity Put(UsuarioEntity usuarioEntity);

    }
}
