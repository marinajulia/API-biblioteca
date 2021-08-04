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
        bool GetByEditora(int editora);
        bool GetByAutor(int autor);
        LivroEntity Put(LivroEntity livroEntity);
        bool Delete(LivroEntity livroEntity);
        IEnumerable<LivroEntity> Get(string nome);
    }
}
