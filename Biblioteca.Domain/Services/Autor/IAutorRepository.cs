using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.Domain.Services.Autor.Entities;
using Biblioteca.Domain.Services.Entidades;


namespace Biblioteca.Domain.Services.Autor
{
    public interface IAutorRepository
    {
        IEnumerable<AutorEntity> Get();
        AutorEntity GetById(int id);
        AutorEntity Post(AutorEntity autor);
        AutorEntity GetByName(string nome);

    }
}
