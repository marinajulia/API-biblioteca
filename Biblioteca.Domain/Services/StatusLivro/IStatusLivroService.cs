using Biblioteca.Domain.Services.StatusLivro.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.StatusLivro
{
    public interface IStatusLivroService
    {
        IEnumerable<StatusLivroDto> Get();
        StatusLivroDto GetById(int id);
        StatusLivroDto Post(StatusLivroDto statusLivroEntity);
    }
}
