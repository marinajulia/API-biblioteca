using Biblioteca.Domain.Services.Categoria.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.CategoriaService
{
    public interface ICategoriaService
    {
        CategoriaDto Post(CategoriaDto categoria);
        IEnumerable<CategoriaDto> Get();
        CategoriaDto GetById(int id);

    }
}
