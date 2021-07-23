using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.UsuarioLivros
{
    public class UsuarioLivrosRepository : IUsuarioLivrosRepository
    {
        public IEnumerable<UsuarioLivrosEntity> Get()
        {
            using(var context = new ApplicationContext())
            {
                var usuarioLivros = context.UsuarioLivros;

                return usuarioLivros.ToList();
            }
        }

        public UsuarioLivrosEntity GetById(int id)
        {
            using(var context = new ApplicationContext())
            {
                var usuarioLivros = context.UsuarioLivros.FirstOrDefault
                    (x => x.UsuarioLivrosId == id);
                return usuarioLivros;
            }
        }

        public UsuarioLivrosEntity GetByIdAndName(int idUsuario, int idLivro)
        {
            using (var context = new ApplicationContext())
            {
                var usuarioLivros = context.UsuarioLivros.FirstOrDefault
                    (x => x.UsuarioId == idUsuario 
                && x.LivroId == idLivro);
                return usuarioLivros;
            }
        }

        public UsuarioLivrosEntity GetByIdUsuario(int id)
        {
            using (var context = new ApplicationContext())
            {
                var usuarioLivros = context.UsuarioLivros.FirstOrDefault
                    (x => x.UsuarioId == id);
                return usuarioLivros;
            }
        }

        public UsuarioLivrosEntity Post(UsuarioLivrosEntity usuarioLivros)
        {
            using (var context = new ApplicationContext())
            {
                context.UsuarioLivros.Add(usuarioLivros); 
                context.SaveChanges();
                return usuarioLivros;
            }
        }
    }
}
