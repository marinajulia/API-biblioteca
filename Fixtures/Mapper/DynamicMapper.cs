//using AutoMapper;
//using Microsoft.Extensions.DependencyInjection;
//using Biblioteca.Domain.Common.Mapper;

//namespace Fixtures.Mapper
//{
//    public static class DynamicMapper
//    {
//        private static ServiceProvider RegisterServices()
//        {
//            var mappingConfig = new MapperConfiguration(m =>
//            {
//                m.AddProfile(new AutoMapperProfile());
//            });

//            var mapper = mappingConfig.CreateMapper();

//            var services = new ServiceCollection()
//            .AddSingleton(mapper)
//            .BuildServiceProvider();

//            return services;
//        }

//        public static T MapTo<T>(object from)
//        {
//            return RegisterServices().GetService<IMapper>()
//                .Map<T>(from);
//        }
//    }
//}
