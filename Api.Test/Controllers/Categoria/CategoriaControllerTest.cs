using Biblioteca.Domain.Services.CategoriaService;
using BibliotecaApi.Controllers.Categoria;
using Fixtures.Categoria;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedKernel.Domain.Notification;
using System.Net;
using Xunit;

namespace Api.Test
{
    public class ControllerTest
    {
        private readonly Mock<ICategoriaService> categoriaService = new Mock<ICategoriaService>();
        private readonly Mock<INotification> notification = new Mock<INotification>();

        [Fact(DisplayName = "CategoriaController, create user must return Ok")]
        [Trait("Api", "Categoria Controller")]
        public void Categoria_Controller_Post_MustReturnOk()
        {
            //arrange
            var categoria = CategoriaFixtureDto.CreateValidCategoria();
            categoriaService.Setup(x => x.Post(categoria)).Returns(categoria);
            var categoriaController = new CategoriaController(categoriaService.Object, notification.Object);

            //Act
            var response = categoriaController.Post(categoria) as OkResult;

            //Assert
            Assert.Equal(((int)HttpStatusCode.OK), response.StatusCode);
        }
    }

}
