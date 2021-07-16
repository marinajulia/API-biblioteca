using Biblioteca.Domain.Services.Usuario.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Usuario
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> Get();
        UsuarioDto GetById(int id);
        UsuarioDto Post(UsuarioDto usuario);
    }
}
