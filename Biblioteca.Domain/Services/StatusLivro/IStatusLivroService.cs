using Biblioteca.Domain.Services.StatusLivro.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.StatusLivro
{
    public interface IStatusLivroService
    {
        IEnumerable<StatusLivroDto> Get();
        IEnumerable<StatusLivroDto> GetNome(string nome);
        StatusLivroDto GetById(int id);
        StatusLivroDto Post(StatusLivroDto statusLivroEntity);
    }
}
