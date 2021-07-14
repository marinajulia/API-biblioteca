using Biblioteca.Domain.Services.PerfilUsuario.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.PerfilUsuario
{
    public interface IPerfilUsuarioService
    {
        IEnumerable<PerfilUsuarioDto> Get();
        PerfilUsuarioDto GetById(int id);
        PerfilUsuarioDto Post(PerfilUsuarioDto perfilUsuarioDto);
    }
}
