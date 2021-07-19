using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.UsuarioLivros
{
    public interface IUsuarioLivrosRepository
    {
        IEnumerable<UsuarioLivrosEntity> Get();
        UsuarioLivrosEntity GetById(int id);
        UsuarioLivrosEntity Post(UsuarioLivrosEntity usuarioLivros);
    }
}
