using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.RepositoryCategoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public bool Delete(CategoriaEntity categoriaEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.Categoria.Remove(categoriaEntity);
                context.SaveChanges();

                return true;
            }
        }

        public IEnumerable<CategoriaEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var categorias = context.Categoria;

                return categorias.ToList();
            }
        }

        public IEnumerable<CategoriaEntity> Get(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var categorias = context.Categoria
                    .Where(x => x.NomeCategoria.Trim().ToLower().Contains(nome));

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
                var categoria = context.Categoria.FirstOrDefault(
                    x => x.NomeCategoria.Trim().ToLower() == nome.Trim().ToLower());
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
