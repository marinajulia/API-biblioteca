using Biblioteca.Domain.Common.Criptografia;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Domain.Services.Usuario.Dto;
using Biblioteca.Infra.Data;
using System;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
       

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
                var jaExiste = context.Usuario.FirstOrDefault(x => x.NomeUsuario == usuario.NomeUsuario);
                if (jaExiste == null)
                {
                    usuario.Senha = PasswordService.Criptografar(usuario.Senha);

                    context.Usuario.Add(usuario);
                    context.SaveChanges();

                    //return new UsuarioDto
                    //{
                    //    UsuarioId = usuario.UsuarioId,
                    //    NomeUsuario = usuario.NomeUsuario,
                    //    StatusUsuarioId = usuario.StatusUsuarioId,
                    //    Email = usuario.Email,
                    //    PerfilUsuarioId = usuario.PerfilUsuarioId
                    //};

                    return usuario;

                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
