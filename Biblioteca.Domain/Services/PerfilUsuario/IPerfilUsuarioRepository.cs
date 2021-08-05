using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.PerfilUsuario
{
    public interface IPerfilUsuarioRepository
    {
        IEnumerable<PerfilUsuarioEntity> Get();
        IEnumerable<PerfilUsuarioEntity> Get(string nome);
        PerfilUsuarioEntity GetById(int id);
        PerfilUsuarioEntity Post(PerfilUsuarioEntity perfilUsuarioEntity);
        PerfilUsuarioEntity GetByName(string nome);
    }
}
