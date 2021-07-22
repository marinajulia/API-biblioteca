using Biblioteca.Domain.Services.PerfilUsuario.Dto;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.SharedKernel;

namespace Biblioteca.Domain.Services.PerfilUsuario
{
    public class PerfilUsuarioService : IPerfilUsuarioService
    {
        private readonly INotification _notification;
        private readonly IPerfilUsuarioRepository _perfilUsuario;
        private readonly UserLoggedData _userLoggedData;

        public PerfilUsuarioService(
            INotification notification, 
            IPerfilUsuarioRepository perfilUsuarioRepository,
            UserLoggedData userLoggedData)
        {
            _notification = notification;
            _perfilUsuario = perfilUsuarioRepository;
            _userLoggedData = userLoggedData;
        }

        public IEnumerable<PerfilUsuarioDto> Get()
        {
            var perfilUsuarios = _perfilUsuario.Get();

            return perfilUsuarios.Select(x => new PerfilUsuarioDto
            {
                PerfilUsuarioId = x.PerfilUsuarioId,
                Perfil = x.Perfil
            });
        }

        public PerfilUsuarioDto GetById(int id)
        {
            var perfilUsuario = _perfilUsuario.GetById(id);

            if (perfilUsuario == null)
                return _notification.AddWithReturn<PerfilUsuarioDto>("O perfil não existe");

            return new PerfilUsuarioDto
            {
                PerfilUsuarioId = perfilUsuario.PerfilUsuarioId,
                Perfil = perfilUsuario.Perfil
            };
        }

        public PerfilUsuarioDto Post(PerfilUsuarioDto perfilUsuarioDto)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<PerfilUsuarioDto>
                    ("Ops.. parece que você não tem permissão para adicionar este perfil de usuário");

            else
            {
                var perfilUsuarioData = _perfilUsuario.GetByName(perfilUsuarioDto.Perfil);
                if (perfilUsuarioData != null)
                    return _notification.AddWithReturn<PerfilUsuarioDto>("Esse perfil já existe");

                var perfilUsuarioEntity = _perfilUsuario.Post(new PerfilUsuarioEntity
                {
                    Perfil = perfilUsuarioDto.Perfil
                });

                return new PerfilUsuarioDto
                {
                    PerfilUsuarioId = perfilUsuarioEntity.PerfilUsuarioId,
                    Perfil = perfilUsuarioEntity.Perfil
                };
            }
           
        }
    }
}
