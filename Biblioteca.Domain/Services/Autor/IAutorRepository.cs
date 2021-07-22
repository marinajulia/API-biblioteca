using System.Collections.Generic;
using Biblioteca.Domain.Services.Autor.Entities;

namespace Biblioteca.Domain.Services.Autor
{
    public interface IAutorRepository
    {
        IEnumerable<AutorEntity> Get();
        AutorEntity GetById(int id);
        AutorEntity Post(AutorEntity autor);
        AutorEntity GetByName(string nome);

    }
}
