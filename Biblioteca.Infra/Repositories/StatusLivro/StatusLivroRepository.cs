using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.StatusLivro.Entities;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.StatusUsuario
{
    public class StatusLivroRepository : IStatusLivroRepository
    {
        public IEnumerable<StatusLivroEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var statusLivros = context.StatusLivro;
                return statusLivros.ToList();
            }
        }

        public IEnumerable<StatusLivroEntity> Get(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var statusLivros = context.StatusLivro
                    .Where(x => x.NomeStatus.Trim().ToLower().Contains(nome));
                return statusLivros.ToList();
            }
        }

        public StatusLivroEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var statusLivro = context.StatusLivro.FirstOrDefault(x => x.StatusLivroId == id);
                return statusLivro;
            }
        }

        public StatusLivroEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var statusLivro = context.StatusLivro.FirstOrDefault(x => x.NomeStatus.Trim().ToLower() == nome.Trim().ToLower());

                return statusLivro;
            }
        }

        public StatusLivroEntity Post(StatusLivroEntity statusLivroEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.StatusLivro.Add(statusLivroEntity);
                context.SaveChanges();

                return statusLivroEntity;
            }
        }
    }
}
