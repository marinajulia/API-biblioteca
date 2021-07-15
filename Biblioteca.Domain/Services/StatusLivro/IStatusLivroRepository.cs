using Biblioteca.Domain.Services.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.StatusLivro.Entities
{
    public interface IStatusLivroRepository
    {
        IEnumerable<StatusLivroEntity> Get();
        StatusLivroEntity GetById(int id);
        StatusLivroEntity Post(StatusLivroEntity statusLivroEntity);
        StatusLivroEntity GetByName(string nome);
    }
}
