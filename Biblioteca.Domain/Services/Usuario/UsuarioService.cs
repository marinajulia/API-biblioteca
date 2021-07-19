using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;
using SharedKernel.Domain.Notification;
using System;

namespace Biblioteca.Domain.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly INotification _notification;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, INotification notification)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
        }

        public UsuarioDto PostCadastro(UsuarioEntity usuario)
        {

            var comparacaoNome = _usuarioRepository.GetByName(usuario.NomeUsuario);

            if (comparacaoNome != null)
                return _notification.AddWithReturn<UsuarioDto>("Este usuário já existe");

            var usuarioEntity = _usuarioRepository.PostCadastro(new UsuarioEntity
            {
                NomeUsuario = usuario.NomeUsuario,
                CPF = usuario.CPF,
                Senha = usuario.Senha,
                StatusUsuarioId = usuario.StatusUsuarioId,
                Email = usuario.Email,
                PerfilUsuarioId = usuario.PerfilUsuarioId
            });
            return new UsuarioDto
            {
                UsuarioId = usuarioEntity.UsuarioId,
                NomeUsuario = usuarioEntity.NomeUsuario,
                StatusUsuarioId = usuarioEntity.StatusUsuarioId,
                Email = usuarioEntity.Email,
                PerfilUsuarioId = usuarioEntity.PerfilUsuarioId
            };
        }

        public UsuarioDto PostLogin(UsuarioEntity usuario)
        {
            var usuarioData = _usuarioRepository.GetUser(usuario.NomeUsuario, usuario.Senha);
            if (usuarioData == null)
                return _notification.AddWithReturn<UsuarioDto>("Usuário ou senha incorretos");
            return new UsuarioDto
            {
                UsuarioId = usuarioData.UsuarioId,
                NomeUsuario = usuarioData.NomeUsuario,
                StatusUsuarioId = usuarioData.StatusUsuarioId,
                Email = usuarioData.Email,
                PerfilUsuarioId = usuarioData.PerfilUsuarioId
            };
        }
    }
}
