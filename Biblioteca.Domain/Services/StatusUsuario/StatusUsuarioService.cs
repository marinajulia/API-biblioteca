using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.StatusUsuario.Dto;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.StatusUsuario
{
    public class StatusUsuarioService : IStatusUsuarioService
    {
        private readonly INotification _notification;
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;

        public StatusUsuarioService(INotification notification, IStatusUsuarioRepository statusUsuarioRepository)
        {
            _notification = notification;
            _statusUsuarioRepository = statusUsuarioRepository;
        }

        public IEnumerable<StatusUsuarioDto> Get()
        {
            var statusUsuario = _statusUsuarioRepository.Get();

            return statusUsuario.Select(x => new StatusUsuarioDto
            {
                StatusUsuarioId = x.StatusUsuarioId,
                NomeStatus = x.NomeStatus,
            });
        }

        public StatusUsuarioDto GetById(int id)
        {
            var statusUsuario = _statusUsuarioRepository.GetById(id);

            if (statusUsuario == null)
                return _notification.AddWithReturn<StatusUsuarioDto>("O status não pode ser encontrado");

            return new StatusUsuarioDto
            {
                StatusUsuarioId = statusUsuario.StatusUsuarioId,
                NomeStatus = statusUsuario.NomeStatus
            };
        }

        public StatusUsuarioDto Post(StatusUsuarioDto statusUsuario)
        {
            var statusUsuarioData = _statusUsuarioRepository.GetByName(statusUsuario.NomeStatus);
            if (statusUsuarioData != null)
                return _notification.AddWithReturn<StatusUsuarioDto>("Ops.. parece que esse status já existe!");

            var statusUsuarioEntity = _statusUsuarioRepository.Post(new StatusUsuarioEntity
            {
                NomeStatus = statusUsuario.NomeStatus,
            });

            return new StatusUsuarioDto
            {
                StatusUsuarioId = statusUsuarioEntity.StatusUsuarioId,
                NomeStatus = statusUsuarioEntity.NomeStatus,
            };
        }
    }
}
