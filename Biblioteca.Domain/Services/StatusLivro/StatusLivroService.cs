using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.StatusLivro.Dto;
using Biblioteca.Domain.Services.StatusLivro.Entities;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.StatusLivro
{
    public class StatusLivroService : IStatusLivroService
    {
        private readonly INotification _notification;
        private readonly IStatusLivroRepository _statusLivro;

        public StatusLivroService(INotification notification, IStatusLivroRepository statusLivro)
        {
            _notification = notification;
            _statusLivro = statusLivro;
        }

        public IEnumerable<StatusLivroDto> Get()
        {
            var statusLivro = _statusLivro.Get();

            return statusLivro.Select(x => new StatusLivroDto
            {
                StatusLivroId = x.StatusLivroId,
                NomeStatus = x.NomeStatus
            });
        }

        public StatusLivroDto GetById(int id)
        {
            var statusLivro = _statusLivro.GetById(id);

            if (statusLivro == null)
                return _notification.AddWithReturn<StatusLivroDto>("O status não existe");

            return new StatusLivroDto
            {
                StatusLivroId = statusLivro.StatusLivroId,
                NomeStatus = statusLivro.NomeStatus
            };
        }

        public StatusLivroDto Post(StatusLivroDto statusLivroEntity)
        {
            var statusLivroData = _statusLivro.GetByName(statusLivroEntity.NomeStatus);
            if (statusLivroData != null)
                return _notification.AddWithReturn<StatusLivroDto>("Esse status já existe");

            var statusLivroEntities = _statusLivro.Post(new StatusLivroEntity
            {
                NomeStatus = statusLivroEntity.NomeStatus
            });

            return new StatusLivroDto
            {
                StatusLivroId = statusLivroEntities.StatusLivroId,
                NomeStatus = statusLivroEntities.NomeStatus
            };
        }
    }
}
