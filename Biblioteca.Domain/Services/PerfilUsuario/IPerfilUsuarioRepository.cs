using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.PerfilUsuario
{
   public interface IPerfilUsuarioRepository
    {
        IEnumerable<PerfilUsuarioEntity> Get();
        PerfilUsuarioEntity GetById(int id);
        PerfilUsuarioEntity Post(PerfilUsuarioEntity perfilUsuarioEntity);
        PerfilUsuarioEntity GetByName(string nome);
    }
}
