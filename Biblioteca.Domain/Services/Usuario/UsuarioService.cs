﻿using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Domain.Services.StatusUsuario;
using Biblioteca.Domain.Services.Usuario.Dto;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<UsuarioDto> Get()
        {
            var usuarios = _usuarioRepository.Get();

            return usuarios.Select(x => new UsuarioDto
            {
                UsuarioId = x.UsuarioId,
                NomeUsuario = x.NomeUsuario,
                StatusUsuarioId = x.StatusUsuarioId,
                StatusUsuario = x.StatusUsuario,
                Email = x.Email,
                PerfilUsuarioId = x.PerfilUsuarioId,
                PerfilUsuario = x.PerfilUsuario

            }).ToList();
        }

        public UsuarioDto GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("O usuario não pode ser encontrado");

            return new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                NomeUsuario = usuario.NomeUsuario,
                StatusUsuarioId = usuario.StatusUsuarioId,
                StatusUsuario = usuario.StatusUsuario,
                Email = usuario.Email,
                PerfilUsuarioId = usuario.PerfilUsuarioId,
                PerfilUsuario = usuario.PerfilUsuario
            };
        }

        public bool PostBloqueio(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetById(usuarioDto.UsuarioId);
            if (usuario == null)
                return _notification.AddWithReturn<bool>("O usuário informado não existe!");

            var statusUsuario = _usuarioRepository.GetByStatus(usuario.UsuarioId);
            if (statusUsuario != null)  
                return _notification.AddWithReturn<bool>
                    ("Ops.. parece que esse usuário já está bloqueado!");

            usuario.StatusUsuarioId = 5;
            var alterandoStatusUsuario = _usuarioRepository.Put(usuario);

            _notification.Add("O usuário foi bloqueado com sucesso!");

            return true;

        }

        public bool PostDesbloqueio(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetById(usuarioDto.UsuarioId);
            if (usuario == null)
                return _notification.AddWithReturn<bool>("O usuário informado não existe!");

            var statusUsuario = _usuarioRepository.GetByStatus(usuario.UsuarioId);
            if (statusUsuario == null)
                return _notification.AddWithReturn<bool>("Ops.. parece que esse usuário já está desbloqueado!");

            usuario.StatusUsuarioId = 6;
            var alterandoStatusUsuario = _usuarioRepository.Put(usuario);

             _notification.Add("O usuário foi desbloqueado com sucesso!");

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

            var verificaSeCpfJaExiste = _usuarioRepository.GetByCpf(usuario.CPF);
            if (verificaSeCpfJaExiste != null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Ops.. parece que o CPF inserido já existe");

            if (usuario.CPF == "" || usuario.Email == "" || usuario.NomeUsuario == "" || usuario.Senha == "")
                return _notification.AddWithReturn<UsuarioDto>
                    ("Ops.. você não pode inserir um campo vazio");


            var validaCpf = _usuarioRepository.ValidaCpf(usuario.CPF);
            if (validaCpf == false)
                return _notification.AddWithReturn<UsuarioDto>
                    ("O CPF é inválido");
           

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

            if (usuario.NomeUsuario == "" || usuario.Senha == "")
                return _notification.AddWithReturn<UsuarioDto>
                    ("Existem campos vazios no login!");

            var usuarioData = _usuarioRepository.GetUser(usuario.NomeUsuario, usuario.Senha);
            if (usuarioData == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Usuário ou senha incorretos");

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
