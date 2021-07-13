using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Domain.Services.Autor.Entities
{
    public class AutorEntity
    {
        [Key]
        public int AutorId { get; set; }
        public string NomeAutor { get; set; }
    }
}
