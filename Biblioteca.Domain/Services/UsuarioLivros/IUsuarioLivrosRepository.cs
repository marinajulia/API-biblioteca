using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.UsuarioLivros
{
    public interface IUsuarioLivrosRepository
    {
        IEnumerable<UsuarioLivrosEntity> Get();
        UsuarioLivrosEntity GetById(int id);
        bool GetByIdLivroUser(int idLivro);
        UsuarioLivrosEntity GetByIdLivro(int id);
        UsuarioLivrosEntity Post(UsuarioLivrosEntity usuarioLivros);
        UsuarioLivrosEntity GetByLivro(int idLivro);
        void Delete(UsuarioLivrosEntity usuarioLivros);
        IEnumerable <UsuarioLivrosEntity> GetLivros(int id);
    }
}
