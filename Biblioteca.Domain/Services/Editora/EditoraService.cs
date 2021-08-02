using Biblioteca.Domain.Services.Editora.Dto;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro;
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
        private readonly ILivroRepository _livroRepository;

        public EditoraService(
            INotification notification,
            IEditoraRepository editoraRepository,
            UserLoggedData userLoggedData,
            ILivroRepository livroRepository)
        {
            _notification = notification;
            _editoraRepository = editoraRepository;
            _userLoggedData = userLoggedData;
            _livroRepository = livroRepository;
        }

        public bool Delete(EditoraDto editora)
        {
            var editoraData = _editoraRepository.GetById(editora.EditoraId);

            if (editoraData == null)
                return _notification.AddWithReturn<bool>("A editora não pode ser encontrada!");

            var livro = _livroRepository.GetByEditora(editora.EditoraId);
            if (livro)
                return _notification.AddWithReturn<bool>
                    ("Você não pode concluir esta operação pois existe(m) livro(s) com esta editora");


            var deleteEditora = _editoraRepository.Delete(editoraData);

            _notification.Add("A editora foi deletada com sucesso!");

            return true;
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
                return _notification.AddWithReturn<EditoraDto>
                    ("A editora não pode ser encontrada!");

            return new EditoraDto
            {
                EditoraId = editora.EditoraId,
                NomeEditora = editora.NomeEditora
            };
        }

        public EditoraDto GetNome(EditoraDto editora)
        {
            var editoraData = _editoraRepository.GetByName(editora.NomeEditora);

            if (editoraData == null)
                return _notification.AddWithReturn<EditoraDto>("Este nome não existe!");

            return new EditoraDto
            {
                EditoraId = editoraData.EditoraId,
                NomeEditora = editoraData.NomeEditora
            };
        }


        public EditoraDto Post(EditoraDto editora)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<EditoraDto>
                    ("Ops.. parece que você não tem permissão para adicionar esta editora!");


            var editoraData = _editoraRepository.GetByName(editora.NomeEditora);
            if (editoraData != null)
                return _notification.AddWithReturn<EditoraDto>
                    ("Ops.. parece que essa editora já existe!");

            if (editora.NomeEditora == "")
                return _notification.AddWithReturn<EditoraDto>
                    ("Você não pode inserir um campo vazio!");

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
