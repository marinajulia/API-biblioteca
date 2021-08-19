using AutoMapper;
using Biblioteca.Domain.Services.Categoria.Dto;
using Biblioteca.Domain.Services.Entidades;

namespace Biblioteca.Domain.Common.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoriaEntity, CategoriaDto>();
            CreateMap<CategoriaDto, CategoriaEntity>();
        }
    }
}
