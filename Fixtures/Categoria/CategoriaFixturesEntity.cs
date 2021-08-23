using Biblioteca.Domain.Services.Entidades;
using System;
using System.Collections.Generic;

namespace Fixtures.Categoria
{
    public static class CategoriaFixtureEntity
    {
        public static CategoriaEntity CreateValidCategoria()
        {
            return new CategoriaEntity
            {
                CategoriaId = 1,
                NomeCategoria = "Romance",
                DescriçãoCategoria = "teste"
            };
        }

        public static CategoriaEntity CreateValidCategoria(string nomeCategoria, string descricaoCategoria)
        {
            var random = new Random();

            return new CategoriaEntity
            {
                CategoriaId = random.Next(1, 10),
                NomeCategoria = nomeCategoria,
                DescriçãoCategoria = descricaoCategoria
            };
        }
        public static CategoriaEntity CreateInvalidCategoria()
        {
            return new CategoriaEntity
            {
                CategoriaId = 0,
                NomeCategoria = "",
                DescriçãoCategoria = "",
            };
        }


        public static IEnumerable<CategoriaEntity> CreateListValidCategorias()
        {
            var categorias = new List<CategoriaEntity>();

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
