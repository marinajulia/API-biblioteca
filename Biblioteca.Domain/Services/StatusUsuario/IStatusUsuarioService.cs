using Biblioteca.Domain.Services.StatusUsuario.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.StatusUsuario
{
    public interface IStatusUsuarioService
    {
        IEnumerable<StatusUsuarioDto> Get();
        StatusUsuarioDto GetById(int id);
        StatusUsuarioDto Post(StatusUsuarioDto statusUsuario);
    }
}
