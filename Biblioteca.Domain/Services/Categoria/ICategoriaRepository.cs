using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaEntity> Get();
        CategoriaEntity GetById(int id);
        CategoriaEntity Post(CategoriaEntity autor);
        CategoriaEntity GetByName(string nome);
    }
}

