using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntity> Get();
        UsuarioEntity GetById(int id);
        UsuarioEntity Post(UsuarioEntity usuario);
        UsuarioEntity GetByName(string nome);
    }
}
