using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Categoria
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaEntity> Get();
        IEnumerable<CategoriaEntity> Get(string nome);
        CategoriaEntity GetById(int id);
        CategoriaEntity Post(CategoriaEntity categoria);
        CategoriaEntity GetByName(string nome);
        bool Delete(CategoriaEntity categoriaEntity);
    }
}

