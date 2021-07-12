using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.Categoria.Dto
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public string DescriçãoCategoria { get; set; }
    }
}
