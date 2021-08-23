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
            //Arrange
            var categoriaInvalida = CategoriaFixtureEntity.CreateInvalidCategoria();

            //var expectedUser = 1;

            categoriaRepository.Setup(x => x.Post(categoriaInvalida)).Returns(categoriaInvalida);

            //Act
            var actualResult = categoriaRepository.Object.Post(categoriaInvalida);

            //Assert
            Assert.False(categoriaInvalida.CategoriaId > 0);
            Assert.False(!string.IsNullOrEmpty(categoriaInvalida.NomeCategoria));
            categoriaRepository.Verify(r => r.Post(It.IsAny<CategoriaEntity>()), Times.Once);
        }

    }
}
