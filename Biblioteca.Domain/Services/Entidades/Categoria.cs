using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Domain.Services.Entidades
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [MaxLength(100, ErrorMessage = "Este compo deve conter entre 1 e 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 100 caracteres")]
        public string NomeCategoria { get; set; }

        [MaxLength(1000, ErrorMessage = "Este compo deve conter entre 1 e 1000 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 1000 caracteres")]
        public string DescriçãoCategoria { get; set; }
    }
}
