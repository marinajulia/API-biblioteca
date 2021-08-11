using Biblioteca.Domain.Services.Categoria.Dto;
using System;
using System.Collections.Generic;

namespace Fixtures.Categoria
{
    public static class CategoriaFixtureDto
    {
        public static CategoriaDto CreateValidCategoria()
        {
            return new CategoriaDto
            {
                CategoriaId = 1,
                NomeCategoria = "Romance",
                DescriçãoCategoria = "teste"
            };
        }


        public static CategoriaDto CreateValidCategoria(string nomeCategoria, string descricaoCategoria)
        {
            var random = new Random();

            return new CategoriaDto
            {
                CategoriaId = random.Next(1, 10),
                NomeCategoria = nomeCategoria,
                DescriçãoCategoria = descricaoCategoria
            };
        }
        public static CategoriaDto CreateInvalidCategoria()
        {
            return new CategoriaDto
            {
                CategoriaId = 2,
                NomeCategoria = "",
                DescriçãoCategoria = "teste",
            };
        }


        public static IEnumerable<CategoriaDto> CreateListValidCategorias()
        {
            var categorias = new List<CategoriaDto>();

            categorias.Add(CreateValidCategoria("Terror", "teste"));
            categorias.Add(CreateValidCategoria("Suspense", "teste"));
            categorias.Add(CreateValidCategoria("Comedia", "teste"));
            categorias.Add(CreateValidCategoria("Aventura", "teste"));
            categorias.Add(CreateValidCategoria("Drama", "teste"));
            categorias.Add(CreateValidCategoria("Comedia Romantica", "teste"));
           
           
            return categorias;
        }
    }
}
