using Biblioteca.Domain.Services.Livro.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Livro
{
    public interface ILivroService
    {
        IEnumerable<LivroDto> Get();
        LivroDto GetById(int id);
        LivroDto Post(LivroDto livro);
        bool Delete(int livro);
        IEnumerable<LivroDto> GetNome(string nome);

    }
}
