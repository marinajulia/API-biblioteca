using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.StatusUsuario;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories
{
    public class StatusUsuarioRepository : IStatusUsuarioRepository
    {
        public IEnumerable<StatusUsuarioEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var statusUsuario = context.StatusUsuario;

                return statusUsuario.ToList();
            }
        }

        public IEnumerable<StatusUsuarioEntity> Get(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var statusUsuario = context.StatusUsuario
                    .Where(x => x.NomeStatus.Trim().ToLower().Contains(nome));

                return statusUsuario.ToList();
            }
        }

        public StatusUsuarioEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var statusUsuario = context.StatusUsuario.FirstOrDefault(x => x.StatusUsuarioId == id);
                return statusUsuario;
            }
        }

        public StatusUsuarioEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var statusUsuario = context.StatusUsuario.FirstOrDefault(x => x.NomeStatus.Trim().ToLower() == nome.Trim().ToLower());
                return statusUsuario;
            }
        }

        public StatusUsuarioEntity Post(StatusUsuarioEntity statusUsuario)
        {
            using (var context = new ApplicationContext())
            {
                context.StatusUsuario.Add(statusUsuario); //para put seria update
                context.SaveChanges();
                return statusUsuario;
            }
        }
    }
}
