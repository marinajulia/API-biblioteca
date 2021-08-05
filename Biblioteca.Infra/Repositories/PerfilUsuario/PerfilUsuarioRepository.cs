using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.PerfilUsuario
{
    public class PerfilUsuarioRepository : IPerfilUsuarioRepository
    {
        public IEnumerable<PerfilUsuarioEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var perfilUsuarios = context.PerfilUsuario;
                return perfilUsuarios.ToList();
            }
        }

        public IEnumerable<PerfilUsuarioEntity> Get(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var perfilUsuarios = context.PerfilUsuario
                    .Where(x => x.Perfil.Trim().ToLower().Contains(nome));
                return perfilUsuarios.ToList();
            }
        }

        public PerfilUsuarioEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var perfilUsuario = context.PerfilUsuario.FirstOrDefault(x => x.PerfilUsuarioId == id);
                return perfilUsuario;
            }
        }

        public PerfilUsuarioEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var perfilUsuario = context.PerfilUsuario.FirstOrDefault(x => x.Perfil.Trim().ToLower() == nome.Trim().ToLower());

                return perfilUsuario;
            }
        }

        public PerfilUsuarioEntity Post(PerfilUsuarioEntity perfilUsuarioEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.PerfilUsuario.Add(perfilUsuarioEntity);
                context.SaveChanges();

                return perfilUsuarioEntity;
            }
        }
    }
}
