using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Categoria.Dto;
using Biblioteca.Domain.Services.Entidades;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly INotification _notification;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(INotification notification, ICategoriaRepository categoriaRepository)
        {
            _notification = notification;
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<CategoriaDto> Get()
        {
            var categorias = _categoriaRepository.Get();

            return categorias.Select(x => new CategoriaDto 
            {
                CategoriaId = x.CategoriaId,
                NomeCategoria = x.NomeCategoria,
                DescriçãoCategoria = x.DescriçãoCategoria
            });
        }


        public CategoriaDto GetById(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
                return _notification.AddWithReturn<CategoriaDto>("A categoria não pode ser encontrada");

            return new CategoriaDto
            {
                CategoriaId = categoria.CategoriaId,
                DescriçãoCategoria = categoria.DescriçãoCategoria,
                NomeCategoria = categoria.NomeCategoria
            };
        }

        public CategoriaDto Post(CategoriaDto categoria)
        {
            var categoriaData = _categoriaRepository.GetByName(categoria.NomeCategoria);
            if (categoriaData != null)
                return _notification.AddWithReturn<CategoriaDto>("Ops.. parece que essa categoria já existe!");

            var categoriaEntity = _categoriaRepository.Post(new CategoriaEntity
            {
                NomeCategoria = categoria.NomeCategoria,
                DescriçãoCategoria = categoria.DescriçãoCategoria
            });

            return new CategoriaDto
            {
                CategoriaId = categoriaEntity.CategoriaId,
                DescriçãoCategoria = categoriaEntity.DescriçãoCategoria,
                NomeCategoria = categoriaEntity.NomeCategoria
            };
        }

        
    }
}
