//using Biblioteca.Domain.Services.Entidades;
//using Biblioteca.Domain.Services.Usuario.Dto;
//using SharedKernel.Domain.Notification;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Biblioteca.Domain.Services.Usuario
//{
//    public class UsuarioService : IUsuarioService
//    {
//        private readonly INotification _notification;
//        private readonly IUsuarioRepository _usuarioRepository;

//        public UsuarioService(IUsuarioRepository usuarioRepository, INotification notification)
//        {
//            _usuarioRepository = usuarioRepository;
//            _notification = notification;
//        }

//        public IEnumerable<UsuarioDto> Get()
//        {
//            var usuarios = _usuarioRepository.Get();

//            return usuarios.Select(x => new UsuarioDto
//            {
//                UsuarioId = x.UsuarioId,
//                NomeUsuario = x.NomeUsuario,
//                StatusUsuarioId = x.StatusUsuarioId,
//                Email = x.Email,
//                PerfilUsuarioId = x.PerfilUsuarioId
//            });
//        }

//        public UsuarioDto GetById(int id)
//        {
//            var usuario = _usuarioRepository.GetById(id);

//            if (usuario == null)
//                return _notification.AddWithReturn<UsuarioDto>("O usuário não pode ser encontrado");

//            return new UsuarioDto
//            {
//                UsuarioId = usuario.UsuarioId,
//                NomeUsuario = usuario.NomeUsuario,
//                StatusUsuarioId = usuario.StatusUsuarioId,
//                Email = usuario.Email,
//                PerfilUsuarioId = usuario.PerfilUsuarioId
//            };
//        }

//        public UsuarioDto Post(UsuarioDto usuario)
//        {
//            var usuarioData = _usuarioRepository.GetByName(usuario.NomeUsuario);
//            if (usuarioData != null)
//                return _notification.AddWithReturn<UsuarioDto>("Ops.. parece que esse usuário já existe!");

//            var usuarioEntity = _usuarioRepository.Post(new UsuarioEntity
//            {
//                NomeUsuario = usuario.NomeUsuario,
//                StatusUsuarioId = usuario.StatusUsuarioId,
//                Email = usuario.Email,
//                PerfilUsuarioId = usuario.PerfilUsuarioId
//            });

//            return new UsuarioDto
//            {
//                UsuarioId = usuarioEntity.UsuarioId,
//                NomeUsuario = usuarioEntity.NomeUsuario,
//                StatusUsuarioId = usuarioEntity.StatusUsuarioId,
//                Email = usuarioEntity.Email,
//                PerfilUsuarioId = usuarioEntity.PerfilUsuarioId
//            };
//        }
//    }
//}
