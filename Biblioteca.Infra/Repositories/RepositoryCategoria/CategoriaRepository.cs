using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Infra.Repositories.RepositoryCategoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public IEnumerable<CategoriaEntity> Get()
        {
            throw new NotImplementedException();
        }

        public CategoriaEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoriaEntity GetByName(string nome)
        {
            throw new NotImplementedException();
        }

        public CategoriaEntity Post(CategoriaEntity autor)
        {
            throw new NotImplementedException();
        }
    }
}
