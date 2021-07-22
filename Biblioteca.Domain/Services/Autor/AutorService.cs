using Biblioteca.Domain.Services.Autor.Dto;
using Biblioteca.Domain.Services.Autor.Entities;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.Autor
{
    public class AutorService : IAutorService
    {
        private readonly INotification _notification;
        private readonly IAutorRepository _autorRepository;
        private readonly UserLoggedData _userLoggedData;

        public AutorService(
            INotification notification,
            IAutorRepository autorRepository,
            UserLoggedData userLoggedData)
        {
            _notification = notification;
            _autorRepository = autorRepository;
            _userLoggedData = userLoggedData;
        }

        public IEnumerable<AutorDto> Get()
        {
            var autores = _autorRepository.Get();

            return autores.Select(x => new AutorDto
            {
                AutorId = x.AutorId,
                NomeAutor = x.NomeAutor

            });
        }

        public AutorDto GetById(int id)
        {
            var autor = _autorRepository.GetById(id);

            if (autor == null)
                return _notification.AddWithReturn<AutorDto>
                    ("O autor não pode ser encontrado");

            return new AutorDto
            {
                AutorId = autor.AutorId,
                NomeAutor = autor.NomeAutor
            };
        }

        public AutorDto Post(AutorDto autorDto)
        {
            var dadosUsuariologado = _userLoggedData.GetData();

            if (dadosUsuariologado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<AutorDto>
                    ("Ops.. parece que você não tem permissão para adicionar este autor");

            var autorData = _autorRepository.GetByName(autorDto.NomeAutor);
            if (autorData != null)
                return _notification.AddWithReturn<AutorDto>
                    ("Ops.. parece que esse autor já existe!");

            var autorEntity = _autorRepository.Post(new AutorEntity
            {
                NomeAutor = autorDto.NomeAutor
            });

            return new AutorDto
            {
                AutorId = autorEntity.AutorId,
                NomeAutor = autorEntity.NomeAutor
            };
        }
    }
}

