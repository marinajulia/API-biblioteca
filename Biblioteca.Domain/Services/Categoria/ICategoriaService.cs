using Biblioteca.Domain.Services.Categoria.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.CategoriaService
{
    public interface ICategoriaService
    {
        CategoriaDto Post(CategoriaDto categoria);
        CategoriaDto GetNome(CategoriaDto categoria);
        bool Delete(CategoriaDto categoria);
        IEnumerable<CategoriaDto> Get();
        CategoriaDto GetById(int id);

    }
}
