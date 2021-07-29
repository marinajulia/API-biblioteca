using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Livro
{
    public interface ILivroRepository
    {
        IEnumerable<LivroEntity> Get();
        LivroEntity GetById(int id);
        LivroEntity Post(LivroEntity livro);
        LivroEntity GetByName(string nome);
        bool GetByCategoria(int categoria);
        LivroEntity Put(LivroEntity livroEntity);
    }
}
