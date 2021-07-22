using Biblioteca.Domain.Common.Criptografia;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Infra.Data;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioEntity GetByCpf(string cpf)
        {
            using(var context = new ApplicationContext())
            {
                var usuarioCpf = context.Usuario.FirstOrDefault(x => x.CPF == cpf);
                return usuarioCpf;
            }
        }

        public UsuarioEntity GetById(int id) {
            using (var context = new ApplicationContext()) {
                var usuario = context.Usuario.FirstOrDefault(x => x.UsuarioId == id);
                return usuario;
            }
        }

        public UsuarioEntity GetByName(string username)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.NomeUsuario == username);
                return usuario;
            }
        }

        public UsuarioEntity GetUser(string username, string password)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.NomeUsuario == username && x.Senha == PasswordService.Criptografar(password));
                return usuario;
            }
        }

        public UsuarioEntity PostCadastro(UsuarioEntity usuario)
        {
            using (var context = new ApplicationContext())
            {
                usuario.Senha = PasswordService.Criptografar(usuario.Senha);

                context.Usuario.Add(usuario);
                context.SaveChanges();

                return usuario;
            }
        }
    }
}
