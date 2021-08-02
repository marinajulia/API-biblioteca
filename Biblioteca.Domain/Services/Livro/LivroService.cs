using Biblioteca.Domain.Services.Autor;
using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Editora;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro.Dto;
using Biblioteca.Domain.Services.StatusLivro.Entities;
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
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IEditoraRepository _editoraRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IStatusLivroRepository _statusLivroRepository;

        public LivroService(
            ILivroRepository livroRepository,
            INotification notification,
            UserLoggedData userLoggedData,
            ICategoriaRepository categoriaRepository,
            IEditoraRepository editoraRepository,
            IAutorRepository autorRepository,
            IStatusLivroRepository statusLivroRepository
            )
        {
            _livroRepository = livroRepository;
            _notification = notification;
            _userLoggedData = userLoggedData;
            _categoriaRepository = categoriaRepository;
            _editoraRepository = editoraRepository;
            _autorRepository = autorRepository;
            _statusLivroRepository = statusLivroRepository;
        }

        public bool Delete(LivroDto livro)
        {
            var livroData = _livroRepository.GetById(livro.LivroId);

            if (livroData == null)
                return _notification.AddWithReturn<bool>("O livro não pode ser encontrado!");

            _livroRepository.Delete(livroData);

            _notification.Add("O livro foi deletado com sucesso!");

            return true;
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
                StatusLivroId = x.StatusLivroId,
                Categoria = x.Categoria,
                Autor = x.Autor,
                Editora = x.Editora,
                StatusLivro = x.StatusLivro
                
            }).ToList();
        }

        public LivroDto GetById(int id)
        {
            var livro = _livroRepository.GetById(id);

            if (livro == null)
                return _notification.AddWithReturn<LivroDto>
                    ("O livro não pode ser encontrado");

            return new LivroDto
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                ISBN = livro.ISBN,
                CategoriaId = livro.CategoriaId,
                AutorId = livro.AutorId,
                Descrição = livro.Descrição,
                EditoraId = livro.EditoraId,
                StatusLivroId = livro.StatusLivroId,
                Categoria = livro.Categoria,
                Autor = livro.Autor,
                Editora = livro.Editora,
                StatusLivro = livro.StatusLivro
            };
        }

        public LivroDto Post(LivroDto livro)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que você não tem permissão para adicionar este livro!");

            var livroData = _livroRepository.GetByName(livro.Titulo);
            if (livroData != null)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que esse livro já existe!");

            var verificaSeCategoriaExiste = _categoriaRepository.GetById(livro.CategoriaId);
            if (verificaSeCategoriaExiste == null)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que a categoria informada não existe!");

            var verificaSeEditoraExiste = _editoraRepository.GetById(livro.EditoraId);
            if (verificaSeEditoraExiste == null)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que a editora informada não existe!");

            var verificaSeAutorExiste = _autorRepository.GetById(livro.AutorId);
            if (verificaSeAutorExiste == null)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que o autor informado não existe!");

            var verificaSeStatusLivroExiste = _statusLivroRepository.GetById(livro.StatusLivroId);
            if (verificaSeStatusLivroExiste == null)
                return _notification.AddWithReturn<LivroDto>
                    ("Ops.. parece que o status do livro informado não existe!");

            if(livro.CategoriaId < 1 || livro.AutorId < 1 || livro.EditoraId < 1 ||
                livro.StatusLivroId < 1)
                return _notification.AddWithReturn<LivroDto>
                    ("Você não pode inserir um campo vazio!");

            if (livro.Descrição == "" || livro.ISBN == "" ||livro.Titulo == "")
                return _notification.AddWithReturn<LivroDto>
                    ("Você não pode inserir um campo vazio!");

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
