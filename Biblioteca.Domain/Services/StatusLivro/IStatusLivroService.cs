using Biblioteca.Domain.Services.StatusLivro.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.StatusLivro
{
    public interface IStatusLivroService
    {
        IEnumerable<StatusLivroDto> Get();
        StatusLivroDto GetById(int id);
        StatusLivroDto Post(StatusLivroDto statusLivroEntity);
    }
}
