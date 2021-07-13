﻿using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Services.Entidades
{
    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }

        [MaxLength(100, ErrorMessage = "Este compo deve conter entre 1 e 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 100 caracteres")]
        public string NomeEditora { get; set; }
    }
}