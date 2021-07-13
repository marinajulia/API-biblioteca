using Biblioteca.Domain.Services.Autor.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services
{
    public interface IAutorService
    {
        AutorDto Post(AutorDto autor);

    }
}
