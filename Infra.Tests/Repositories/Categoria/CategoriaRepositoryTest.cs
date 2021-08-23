using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using Fixtures.Categoria;
using FluentAssertions;
using Moq;
using Xunit;

namespace Infra.Tests.Repositories.Categoria
{
    public class CategoriaRepositoryTest
    {
        private readonly Mock<ICategoriaRepository> categoriaRepository = new Mock<ICategoriaRepository>();

        [Fact(DisplayName = "CategoriaRepository, create category should return success")]
        [Trait("Infra", "Categoria Repository")]
        public void CategoriaRepository_CreateCategoria_MustReturnSuccess()
        {
            var categoria = CategoriaFixtureEntity.CreateValidCategoria();

            categoriaRepository.Setup(x => x.Post(categoria)).Returns(categoria);

            var actualResult = categoriaRepository.Object.Post(categoria);

            Assert.Equal(categoria, actualResult);

            categoria.Should().BeEquivalentTo(actualResult);
            categoriaRepository.Verify(r => r.Post(It.IsAny<CategoriaEntity>()), Times.Once);
        }


        [Fact(DisplayName = "CategoriaRepository, create category should return error")]
        [Trait("Infra", "Categoria Repository")]
        public void CategoriaRepository_CreateCategoria_MustReturnError()
        {
            var categoriaInvalida = CategoriaFixtureEntity.CreateInvalidCategoria();

            categoriaRepository.Setup(x => x.Post(categoriaInvalida)).Returns(categoriaInvalida);

            var actualResult = categoriaRepository.Object.Post(categoriaInvalida);

            Assert.False(categoriaInvalida.CategoriaId > 0);
            Assert.False(!string.IsNullOrEmpty(categoriaInvalida.NomeCategoria));
            categoriaRepository.Verify(r => r.Post(It.IsAny<CategoriaEntity>()), Times.Once);
        }


        [Fact(DisplayName = "CategoriaRepository, get categoria by id categoria must return Success")]
        [Trait("Infra", "Categoria Repository")]
        public void UserRepository_GetUserById_MustReturnSuccess()
        {
            var categoria = CategoriaFixtureEntity.CreateValidCategoria();

            categoriaRepository.Setup(x => x.GetById(categoria.CategoriaId)).Returns(categoria);

            var resultCategoria = categoriaRepository.Object.GetById(categoria.CategoriaId);

            Assert.Equal(categoria, resultCategoria);
            Assert.NotNull(resultCategoria);
            Assert.IsType<CategoriaEntity>(resultCategoria);
        }


        [Fact(DisplayName = "CategoriaRepository, get categoria by id user must return Error")]
        [Trait("Infra", "User Repository")]
        public void CategoriaRepository_GetCategoriaById_MustReturnError()
        {
            var categoria = CategoriaFixtureEntity.CreateValidCategoria();

            categoriaRepository.Setup(x => x.GetById(categoria.CategoriaId))
                .Returns(CategoriaFixtureEntity.CreateValidCategoria("testeCategoria", "descrição"));

            var resultCategoria = categoriaRepository.Object.GetById(categoria.CategoriaId);

            Assert.NotEqual(categoria, resultCategoria);
            Assert.NotNull(resultCategoria);
        }
    }
}
