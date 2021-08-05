using Biblioteca.Domain.Services.PerfilUsuario.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.PerfilUsuario
{
    public interface IPerfilUsuarioService
    {
        IEnumerable<PerfilUsuarioDto> Get();
        IEnumerable<PerfilUsuarioDto> GetNome(string nome);
        PerfilUsuarioDto GetById(int id);
        PerfilUsuarioDto Post(PerfilUsuarioDto perfilUsuarioDto);
    }
}
