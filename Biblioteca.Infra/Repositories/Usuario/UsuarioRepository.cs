//using Biblioteca.Domain.Services.Entidades;
//using Biblioteca.Domain.Services.Usuario;
//using Biblioteca.Infra.Data;
//using System.Collections.Generic;
//using System.Linq;

//namespace Biblioteca.Infra.Repositories.Usuario
//{
//    public class UsuarioRepository : IUsuarioRepository
//    {
//        public IEnumerable<UsuarioEntity> Get()
//        {
//            using (var context = new ApplicationContext())
//            {
//                var usuarios = context.Usuario;

//                return usuarios.ToList();
//            }
//        }

//        public UsuarioEntity GetById(int id)
//        {
//            using (var context = new ApplicationContext())
//            {
//                var usuarios = context.Usuario.FirstOrDefault(x => x.UsuarioId == id);
//                return usuarios;
//            }
//        }

//        public UsuarioEntity GetByName(string nome)
//        {
//            using (var context = new ApplicationContext())
//            {
//                var usuarios = context.Usuario.FirstOrDefault(x => x.NomeUsuario.Trim().ToLower() == nome.Trim().ToLower());
//                return usuarios;
//            }
//        }

//        public UsuarioEntity Post(UsuarioEntity usuario)
//        {
//            using (var context = new ApplicationContext())
//            {
//                context.Usuario.Add(usuario); //para put seria update
//                context.SaveChanges();
//                return usuario;
//            }
//        }
//    }
//}
