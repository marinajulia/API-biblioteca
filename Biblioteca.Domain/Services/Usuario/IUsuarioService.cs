using Biblioteca.Domain.Services.Usuario.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioDto GetUser(string nome, string senha);
        UsuarioDto GetById(int id);
        UsuarioDto Post(UsuarioDto usuario);
    }
}
