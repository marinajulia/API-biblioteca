using Biblioteca.Domain.Common.Criptografia;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {

        IEnumerable<UsuarioEntity> IUsuarioRepository.Get()
        {
            using (var context = new ApplicationContext())
            {
                var usuarios = context.Usuario
                    .Include(x => x.PerfilUsuario)
                    .Include(x => x.StatusUsuario)
                    .AsNoTracking();

                return usuarios.ToList();
            }
        }


        public UsuarioEntity GetByCpf(string cpf)
        {
            using (var context = new ApplicationContext())
            {
                var usuarioCpf = context.Usuario.FirstOrDefault(x => x.CPF == cpf);
                return usuarioCpf;
            }
        }

        public UsuarioEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.Usuario
                    .Include(x => x.PerfilUsuario)
                    .Include(x => x.StatusUsuario)
                    .FirstOrDefault(x => x.UsuarioId == id);
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

        public UsuarioEntity GetByStatus(int id)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.UsuarioId == id && x.StatusUsuarioId == 5);
                return usuario;
            }
        }

        public UsuarioEntity GetUser(string username, string password)
        {
            using (var context = new ApplicationContext())
            {
                var usuario = context.Usuario.FirstOrDefault(x => x.NomeUsuario == username &&
                x.Senha == PasswordService.Criptografar(password));
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

        public UsuarioEntity PutAlterarSenha(UsuarioEntity usuario)
        {
            using (var context = new ApplicationContext())
            {
                usuario.Senha = PasswordService.Criptografar(usuario.Senha);
                context.Usuario.Update(usuario);
                context.SaveChanges();

                return usuario;
            }
        }

        public UsuarioEntity Put(UsuarioEntity usuarioEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.Usuario.Update(usuarioEntity);
                context.SaveChanges();
                return usuarioEntity;
            }
        }

        public bool ValidaCpf(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string auxCpf, digito;
            int soma, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            auxCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;

            else
                resto = 11 - resto;


            digito = resto.ToString();
            auxCpf = auxCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;

            else
                resto = 11 - resto;

            auxCpf = auxCpf + resto;

            return cpf == auxCpf;
        }


    }
}
