using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Infra.Repositories.RepositoryCategoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public IEnumerable<CategoriaEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var categorias = context.Categoria;

                return categorias.ToList();
            }
        }

        public CategoriaEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var categoria = context.Categoria.FirstOrDefault(x => x.CategoriaId == id);
                return categoria;
            }
        }

        public CategoriaEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var categoria = context.Categoria.FirstOrDefault(x => x.NomeCategoria.Trim().ToLower() == nome.Trim().ToLower());
                return categoria;
            }
        }

        public CategoriaEntity Post(CategoriaEntity categoria)
        {
            using (var context = new ApplicationContext())
            {
                context.Categoria.Add(categoria); //para put seria update
                context.SaveChanges();
                return categoria;
            }
        }
    }
}
