//using Biblioteca.Domain.Services.CategoriaService;
//using BibliotecaApi.Controllers.Categoria;
//using Fixtures.Categoria;
//using Moq;
//using SharedKernel.Domain.Notification;
//using Xunit;

//namespace Api.Test
//{
//    public class ControllerTest
//    {
//        private readonly Mock<ICategoriaService> categoriaService = new Mock<ICategoriaService>();
//        private readonly Mock<INotification> notification = new Mock<INotification>();

//        [Fact(DisplayName = "CategoriaController, create user must return Ok")]
//        [Trait("Api", "Categoria Controller")]

//        public void Categoria_Controller_Post_MustReturnOk()
//        {
//            var categoria = CategoriaFixtureDto.CreateValidCategoria();
//            categoriaService.Setup(x => x.Post(categoria)).Returns(true);
//            var categoriaController = new CategoriaController(categoriaService.Object, notification.Object);
//        }

//    }
//}