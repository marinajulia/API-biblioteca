using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using Biblioteca.SharedKernel;
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
        private readonly UserLoggedData _userLoggedData;

        public UsuarioLivrosService(
            INotification notification,
            IUsuarioLivrosRepository usuarioLivrosRepository,
            UserLoggedData userLoggedData)
        {
            _notification = notification;
            _usuarioLivrosRepository = usuarioLivrosRepository;
            _userLoggedData = userLoggedData;
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
                return _notification.AddWithReturn<UsuarioLivrosDto>
                    ("Não foi encontrado nenhum registro com esse ID");

            return new UsuarioLivrosDto
            {
                UsuarioLivrosId = usuario.UsuarioLivrosId,
                UsuarioId = usuario.UsuarioId,
                LivroId = usuario.LivroId
            };
        }

        public UsuarioLivrosDto Post(UsuarioLivrosEntity usuarioLivros)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<UsuarioLivrosDto>
                    ("Ops.. parece que você não tem permissão para adicionar esta relação" +
                    " de usuários e livros");

            var VerificarSeUsuarioPegouLivro = _usuarioLivrosRepository.GetByIdAndName(usuarioLivros.UsuarioId, usuarioLivros.LivroId);

            if (VerificarSeUsuarioPegouLivro != null)
                return _notification.AddWithReturn<UsuarioLivrosDto>
                    ("Ops.. parece que esse cadastro já foi feito!");

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
