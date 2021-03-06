using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.UsuarioLivros
{
    public interface IUsuarioLivrosService
    {
        IEnumerable<UsuarioLivrosDto> Get();
        UsuarioLivrosDto GetById(int id);
        UsuarioLivrosDto Post(UsuarioLivrosDto usuarioLivros);
        bool PostDevolucao(UsuarioLivrosDto usuarioLivros);
        IEnumerable<UsuarioLivrosDto> GetUser(int id);
    }
}
