using Biblioteca.Domain.Services.Autor;
using Biblioteca.Domain.Services.Autor.Entities;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Autor
{
    public class AutorRepository : IAutorRepository
    {
        public bool Delete(AutorEntity autorEntity)
        {
            using(var context = new ApplicationContext())
            {
                context.Autor.Remove(autorEntity);
                context.SaveChanges();

                return true;
            }
        }

        public IEnumerable<AutorEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var autores = context.Autor;

                return autores.ToList();
            }
        }

        public IEnumerable<AutorEntity> Get(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var autores = context.Autor
                    .Where(x => x.NomeAutor.Trim().ToLower().Contains(nome));

                return autores.ToList();
            }
        }

        public AutorEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var autor = context.Autor.FirstOrDefault(x => x.AutorId == id);
                return autor;
            }
        }

        public AutorEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var autor = context.Autor.FirstOrDefault(x => x.NomeAutor.Trim().ToLower() == nome.Trim().ToLower());
                return autor;
            }
        }

        public AutorEntity Post(AutorEntity autor)
        {
            using (var context = new ApplicationContext())
            {
                context.Autor.Add(autor);
                context.SaveChanges();
                return autor;
            }
        }
    }
}
