using Biblioteca.Domain.Services.Editora.Dto;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.Editora
{
    public class EditoraService : IEditoraService
    {
        private readonly INotification _notification;
        private readonly IEditoraRepository _editoraRepository;
        private readonly UserLoggedData _userLoggedData;

        public EditoraService(INotification notification, IEditoraRepository editoraRepository, UserLoggedData userLoggedData)
        {
            _notification = notification;
            _editoraRepository = editoraRepository;
            _userLoggedData = userLoggedData;
        }


        public IEnumerable<EditoraDto> Get()
        {
            var editoras = _editoraRepository.Get();

            return editoras.Select(x => new EditoraDto
            {
                EditoraId = x.EditoraId,
                NomeEditora = x.NomeEditora
            });
        }


        public EditoraDto GetById(int id)
        {
            var editora = _editoraRepository.GetById(id);

            if (editora == null)
                return _notification.AddWithReturn<EditoraDto>("A editora não pode ser encontrada");

            return new EditoraDto
            {
                EditoraId = editora.EditoraId,
                NomeEditora = editora.NomeEditora
            };
        }

        public EditoraDto Post(EditoraDto editora)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<EditoraDto>("Ops.. parece que você não tem permissão para adicionar esta editora");

            else
            {
                var editoraData = _editoraRepository.GetByName(editora.NomeEditora);
                if (editoraData != null)
                    return _notification.AddWithReturn<EditoraDto>("Ops.. parece que essa editora já existe!");

                var editoraEntity = _editoraRepository.Post(new EditoraEntity
                {
                    NomeEditora = editora.NomeEditora,
                });

                return new EditoraDto
                {
                    EditoraId = editoraEntity.EditoraId,
                    NomeEditora = editoraEntity.NomeEditora
                };
            }
        }
    }
}
