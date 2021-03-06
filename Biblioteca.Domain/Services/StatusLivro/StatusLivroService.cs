using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro;
using Biblioteca.Domain.Services.StatusLivro.Dto;
using Biblioteca.Domain.Services.StatusLivro.Entities;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.StatusLivro
{
    public class StatusLivroService : IStatusLivroService
    {
        private readonly INotification _notification;
        private readonly IStatusLivroRepository _statusLivro;
        private readonly UserLoggedData _userLoggedData;
        private readonly ILivroRepository _livroRepository;

        public StatusLivroService(
            INotification notification,
            IStatusLivroRepository statusLivro,
            UserLoggedData userLoggedData,
            ILivroRepository livroRepository)
        {
            _notification = notification;
            _statusLivro = statusLivro;
            _userLoggedData = userLoggedData;
            _livroRepository = livroRepository;
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
                return _notification.AddWithReturn<StatusLivroDto>("O status não existe!");

            return new StatusLivroDto
            {
                StatusLivroId = statusLivro.StatusLivroId,
                NomeStatus = statusLivro.NomeStatus
            };
        }

        public IEnumerable<StatusLivroDto> GetNome(string nome)
        {

            var statusLivro = _statusLivro.Get(nome);

            return statusLivro.Select(x => new StatusLivroDto
            {
                StatusLivroId = x.StatusLivroId,
                NomeStatus = x.NomeStatus
            });
        }

        public StatusLivroDto Post(StatusLivroDto statusLivroEntity)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<StatusLivroDto>
                    ("Ops.. parece que você não tem permissão para adicionar esta categoria");

            var statusLivroData = _statusLivro.GetByName(statusLivroEntity.NomeStatus);
            if (statusLivroData != null)
                return _notification.AddWithReturn<StatusLivroDto>("Esse status já existe");

            if (statusLivroEntity.NomeStatus == "")
                return _notification.AddWithReturn<StatusLivroDto>
                    ("Ops.. você não pode inserir um campo vazio");

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
