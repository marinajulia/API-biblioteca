using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.StatusUsuario
{
    public interface IStatusUsuarioRepository
    {
        IEnumerable<StatusUsuarioEntity> Get();
        IEnumerable<StatusUsuarioEntity> Get(string nome);
        StatusUsuarioEntity GetById(int id);
        StatusUsuarioEntity Post(StatusUsuarioEntity statusUsuario);
        StatusUsuarioEntity GetByName(string nome);
    }
}
