using Biblioteca.Domain.Services.Autor.Entities;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Autor
{
    public interface IAutorRepository
    {
        IEnumerable<AutorEntity> Get();
        IEnumerable<AutorEntity> Get(string nome);
        AutorEntity GetById(int id);
        AutorEntity Post(AutorEntity autor);
        AutorEntity GetByName(string nome);
        bool Delete(AutorEntity autorEntity);

    }
}
