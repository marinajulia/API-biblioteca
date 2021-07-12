using Biblioteca.Domain.Services.Categoria.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.CategoriaService
{
    public interface ICategoriaService
    {
        CategoriaDto Post(CategoriaDto categoria);
    }
}
