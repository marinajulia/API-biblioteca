using Biblioteca.Domain.Services.Autor.Dto;
using Biblioteca.Domain.Services.Autor.Entities;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Services.Autor
{
    public class AutorService : IAutorService
    {
        private readonly INotification _notification;
        private readonly IAutorRepository _autorRepository;

        public AutorService(INotification notification, IAutorRepository autorRepository)
        {
            _notification = notification;
            _autorRepository = autorRepository;

        }
        public AutorDto Post(AutorDto autor)
        {
            var autorData = _autorRepository.GetByName(autor.NomeAutor);
            if (autorData != null)
                return _notification.AddWithReturn<AutorDto>("Ops.. parece que esse autor já existe!");

            var autorEntity = _autorRepository.Post(new AutorEntity
            {
                NomeAutor = autor.NomeAutor,
            });

            return new AutorDto
            {
                AutorId = autorEntity.AutorId,
                NomeAutor = autorEntity.NomeAutor
            };
        }
    }
}

