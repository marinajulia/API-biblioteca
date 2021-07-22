using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Domain.Services.StatusUsuario;
using Biblioteca.Domain.Services.Usuario.Dto;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System;

namespace Biblioteca.Domain.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly INotification _notification;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UserLoggedData _userLoggedData;
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository, 
            INotification notification, 
            UserLoggedData userLoggedData,
            IPerfilUsuarioRepository perfilUsuarioRepository,
            IStatusUsuarioRepository statusUsuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
            _userLoggedData = userLoggedData;
            _perfilUsuarioRepository = perfilUsuarioRepository;
            _statusUsuarioRepository = statusUsuarioRepository;
        }

        public bool Allow(int idUser) 
        {
            var usuarioData = _usuarioRepository.GetById(idUser);
            if (usuarioData == null)
                return _notification.AddWithReturn<bool>("Usuário ou senha incorretos");

            _userLoggedData.Add(usuarioData.UsuarioId, usuarioData.PerfilUsuarioId);

            return true;
        }

        public UsuarioDto PostCadastro(UsuarioEntity usuario)
        {
            var comparacaoNome = _usuarioRepository.GetByName(usuario.NomeUsuario);
            if (comparacaoNome != null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Ops.. parece que o usuário informado já existe");

            var verifificaSePerfilUsuarioExiste = _perfilUsuarioRepository.GetById(usuario.PerfilUsuarioId);
            if (verifificaSePerfilUsuarioExiste == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Ops.. parece que o perfil de usuário informado não existe");

            var verificaSeStatusUsuarioExiste = _statusUsuarioRepository.GetById(usuario.StatusUsuarioId);
            if (verificaSeStatusUsuarioExiste == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Ops.. parece que o status de usuário informado não existe");

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
