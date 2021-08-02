using Biblioteca.Domain.Services.Autor.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services
{
    public interface IAutorService
    {
        AutorDto Post(AutorDto autorDto);
        IEnumerable<AutorDto> Get();
        AutorDto GetById(int id);
        bool Delete(AutorDto autor);
        AutorDto GetNome(AutorDto autor);
    }
}
