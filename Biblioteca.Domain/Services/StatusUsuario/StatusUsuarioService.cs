using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.StatusUsuario.Dto;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.StatusUsuario
{
    public class StatusUsuarioService : IStatusUsuarioService
    {
        private readonly INotification _notification;
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;
        private readonly UserLoggedData _userLoggedData;

        public StatusUsuarioService(
            INotification notification,
            IStatusUsuarioRepository statusUsuarioRepository,
            UserLoggedData userLoggedData)
        {
            _notification = notification;
            _statusUsuarioRepository = statusUsuarioRepository;
            _userLoggedData = userLoggedData;
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
                return _notification.AddWithReturn<StatusUsuarioDto>
                    ("O status não pode ser encontrado");

            return new StatusUsuarioDto
            {
                StatusUsuarioId = statusUsuario.StatusUsuarioId,
                NomeStatus = statusUsuario.NomeStatus
            };
        }

        public IEnumerable<StatusUsuarioDto> GetNome(string nome)
        {
            var statusUsuario = _statusUsuarioRepository.Get(nome);

            return statusUsuario.Select(x => new StatusUsuarioDto
            {
                StatusUsuarioId = x.StatusUsuarioId,
                NomeStatus = x.NomeStatus,
            });
        }

        public StatusUsuarioDto Post(StatusUsuarioDto statusUsuario)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<StatusUsuarioDto>
                    ("Ops.. parece que você não tem permissão para adicionar este status de usuário!");

            var statusUsuarioData = _statusUsuarioRepository.GetByName(statusUsuario.NomeStatus);
            if (statusUsuarioData != null)
                return _notification.AddWithReturn<StatusUsuarioDto>
                    ("Ops.. parece que esse status já existe!");

            if (statusUsuario.NomeStatus == "")
                return _notification.AddWithReturn<StatusUsuarioDto>
                    ("Ops.. você não pode inserir um campo vazio!");

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
