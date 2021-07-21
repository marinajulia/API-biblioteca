using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro.Dto;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.Livro
{
    public class LivroService : ILivroService
    {
        private readonly INotification _notification;
        private readonly ILivroRepository _livroRepository;
        private readonly UserLoggedData _userLoggedData;

        public LivroService(ILivroRepository livroRepository, INotification notification, UserLoggedData userLoggedData)
        {
            _livroRepository = livroRepository;
            _notification = notification;
            _userLoggedData = userLoggedData;
        }

        public IEnumerable<LivroDto> Get()
        {
            var livros = _livroRepository.Get();

            return livros.Select(x => new LivroDto
            {
                LivroId = x.LivroId,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                CategoriaId = x.CategoriaId,
                AutorId = x.AutorId,
                Descrição = x.Descrição,
                EditoraId = x.EditoraId,
                StatusLivroId = x.StatusLivroId
            });
        }

        public LivroDto GetById(int id)
        {
            var livro = _livroRepository.GetById(id);

            if (livro == null)
                return _notification.AddWithReturn<LivroDto>("A categoria não pode ser encontrada");

            return new LivroDto
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                ISBN = livro.ISBN,
                CategoriaId = livro.CategoriaId,
                AutorId = livro.AutorId,
                Descrição = livro.Descrição,
                EditoraId = livro.EditoraId,
                StatusLivroId = livro.StatusLivroId
            };
        }

        public LivroDto Post(LivroDto livro)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            //if(dadosUsuarioLogado.Id_PerfilUsuario == 4)


            var livroData = _livroRepository.GetByName(livro.Titulo);
            if (livroData != null)
                return _notification.AddWithReturn<LivroDto>("Ops.. parece que esse livro já existe!");

            var livroEntity = _livroRepository.Post(new LivroEntity
            {
                Titulo = livro.Titulo,
                ISBN = livro.ISBN,
                CategoriaId = livro.CategoriaId,
                AutorId = livro.AutorId,
                Descrição = livro.Descrição,
                EditoraId = livro.EditoraId,
                StatusLivroId = livro.StatusLivroId
            });

            return new LivroDto
            {
                LivroId = livroEntity.LivroId,
                Titulo = livroEntity.Titulo,
                ISBN = livroEntity.ISBN,
                CategoriaId = livroEntity.CategoriaId,
                AutorId = livroEntity.AutorId,
                Descrição = livroEntity.Descrição,
                EditoraId = livroEntity.EditoraId,
                StatusLivroId = livroEntity.StatusLivroId
            };
        }
    }
}
