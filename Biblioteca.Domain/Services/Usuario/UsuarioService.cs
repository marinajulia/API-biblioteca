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

        public UsuarioDto PostCadastro(UsuarioDto usuario)
        {
            throw new NotImplementedException();
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
