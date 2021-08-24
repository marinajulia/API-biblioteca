using AutoMapper;
using Biblioteca.Domain.Services.Categoria;
using Moq;
using SharedKernel.Domain.Notification;
using Xunit;
;

namespace Domain.Tests.Services.Categoria
{
    public class CategoriaServiceTest
    {

        private readonly Mock<ICategoriaRepository> userRepository = new Mock<ICategoriaRepository>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly Mock<INotification> notification = new Mock<INotification>();

        [Fact(DisplayName = "UserService, create user must return Success")]
        [Trait("Domain", "User Service")]
        public void UserService_Post_MustReturnSuccess()
        {
            ////Arrange
            //var user = UserFixtureDto.CreateValidAdmin();
            //int idResult = 1;

            //var userEntity = DynamicMapper.MapTo<UserEntity>(user);

            //userRepository.Setup(x => x.Post(userEntity)).Returns(idResult);
            //mapper.Setup(x => x.Map<UserEntity>(user)).Returns(userEntity);

            //var userService = new UserService(userRepository.Object, mapper.Object, notification.Object);

            ////Act
            //var response = userService.Post(user);

            ////Assert
            //Assert.True(response);
            //Assert.True(user.IsValid(notification.Object));
            //Assert.IsType<UserDto>(user);
        }
    }
}
