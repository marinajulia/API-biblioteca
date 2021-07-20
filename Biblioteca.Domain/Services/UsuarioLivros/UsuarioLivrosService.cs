using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.UsuarioLivros
{
    public class UsuarioLivrosService : IUsuarioLivrosService
    {
        private readonly IUsuarioLivrosRepository _usuarioLivrosRepository;
        private readonly INotification _notification;

        public UsuarioLivrosService(INotification notification, IUsuarioLivrosRepository usuarioLivrosRepository)
        {
            _notification = notification;
            _usuarioLivrosRepository = usuarioLivrosRepository;
        }

        public IEnumerable<UsuarioLivrosDto> Get()
        {
            var usuario = _usuarioLivrosRepository.Get();

            return usuario.Select(x => new UsuarioLivrosDto
            {
                UsuarioLivrosId = x.UsuarioLivrosId,
                UsuarioId = x.UsuarioId,
                LivroId = x.LivroId
            });
        }

        public UsuarioLivrosDto GetById(int id)
        {
            var usuario = _usuarioLivrosRepository.GetById(id);

            if (usuario == null)
                return _notification.AddWithReturn<UsuarioLivrosDto>("Não foi encontrado nenhum registro com esse ID");

            return new UsuarioLivrosDto
            {
                UsuarioLivrosId = usuario.UsuarioLivrosId,
                UsuarioId = usuario.UsuarioId,
                LivroId = usuario.LivroId
            };
        }

        public UsuarioLivrosDto Post(UsuarioLivrosEntity usuarioLivros)
        {
            var VerificarSeUsuarioPegouLivro = _usuarioLivrosRepository.GetByIdAndName(usuarioLivros.UsuarioId, usuarioLivros.LivroId);

            if (VerificarSeUsuarioPegouLivro != null)
                return _notification.AddWithReturn<UsuarioLivrosDto>("Ops.. parece que esse cadastro já foi feito!");

            var usuarioLivrosEntity = _usuarioLivrosRepository.Post(new UsuarioLivrosEntity
            {
                UsuarioId = usuarioLivros.UsuarioId,
                LivroId = usuarioLivros.LivroId

            });

            return new UsuarioLivrosDto
            {
                UsuarioLivrosId = usuarioLivrosEntity.UsuarioLivrosId,
                UsuarioId = usuarioLivrosEntity.UsuarioId,
                LivroId = usuarioLivrosEntity.LivroId
            };
        }
    }
}
