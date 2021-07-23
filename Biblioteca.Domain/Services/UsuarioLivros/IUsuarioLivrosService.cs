using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.UsuarioLivros
{
    public interface IUsuarioLivrosService
    {
        IEnumerable<UsuarioLivrosDto> Get();
        UsuarioLivrosDto GetById(int id);
        UsuarioLivrosDto Post(UsuarioLivrosEntity usuarioLivros);
        UsuarioLivrosDto PostDevolucao(UsuarioLivrosEntity usuarioLivros);
    }
}
