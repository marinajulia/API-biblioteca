using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Categoria.Dto;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro;
using Biblioteca.SharedKernel;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.CategoriaService
{
    public class CategoriaService : ICategoriaService
    {
        private readonly INotification _notification;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly UserLoggedData _userLoggedData;
        private readonly ILivroRepository _livroRepository;

        public CategoriaService(
            INotification notification,
            ICategoriaRepository categoriaRepository,
            UserLoggedData userLoggedData,
            ILivroRepository livroRepository)
        {
            _notification = notification;
            _categoriaRepository = categoriaRepository;
            _userLoggedData = userLoggedData;
            _livroRepository = livroRepository;
        }

        public bool Delete(CategoriaDto categoria)
        {

            var categoriaData = _categoriaRepository.GetById(categoria.CategoriaId);

            if (categoriaData == null)
                return _notification.AddWithReturn<bool>("A categoria não pode ser encontrada!");

            var livro = _livroRepository.GetByCategoria(categoria.CategoriaId);
            if (livro)
                return _notification.AddWithReturn<bool>
                    ("Você não pode concluir esta operação pois existe(m) livro(s) com esta categoria");


            _categoriaRepository.Delete(categoriaData);

            _notification.Add("A categoria foi deletada com sucesso!");

            return true;
        }

        public IEnumerable<CategoriaDto> Get()
        {
            var categorias = _categoriaRepository.Get();

            return categorias.Select(x => new CategoriaDto
            {
                CategoriaId = x.CategoriaId,
                NomeCategoria = x.NomeCategoria,
                DescriçãoCategoria = x.DescriçãoCategoria
            });
        }

        public CategoriaDto GetById(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
                return _notification.AddWithReturn<CategoriaDto>
                    ("A categoria não pode ser encontrada!");

            return new CategoriaDto
            {
                CategoriaId = categoria.CategoriaId,
                DescriçãoCategoria = categoria.DescriçãoCategoria,
                NomeCategoria = categoria.NomeCategoria
            };
        }

        public CategoriaDto GetNome(CategoriaDto categoria)
        {
            var categoriaData = _categoriaRepository.GetByName(categoria.NomeCategoria);

            if (categoriaData == null)
                return _notification.AddWithReturn<CategoriaDto>("Este nome não existe!");

            return new CategoriaDto
            {
                CategoriaId = categoriaData.CategoriaId,
                DescriçãoCategoria = categoriaData.DescriçãoCategoria,
                NomeCategoria = categoriaData.NomeCategoria
            };
        }

        public CategoriaDto Post(CategoriaDto categoria)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<CategoriaDto>
                    ("Ops.. parece que você não tem permissão para adicionar esta categoria!");

            var categoriaData = _categoriaRepository.GetByName(categoria.NomeCategoria);
            if (categoriaData != null)
                return _notification.AddWithReturn<CategoriaDto>
                    ("Ops.. parece que essa categoria já existe!");

            if (categoria.NomeCategoria == "" || categoria.DescriçãoCategoria == "") 
                return _notification.AddWithReturn<CategoriaDto>
                    ("Você não pode inserir um campo vazio!");

            if (categoria.DescriçãoCategoria == null)
                return _notification.AddWithReturn<CategoriaDto>
                    ("Você não pode inserir uma descrição nula!");

            var categoriaEntity = _categoriaRepository.Post(new CategoriaEntity
            {
                NomeCategoria = categoria.NomeCategoria,
                DescriçãoCategoria = categoria.DescriçãoCategoria
            });

            return new CategoriaDto
            {
                CategoriaId = categoriaEntity.CategoriaId,
                DescriçãoCategoria = categoriaEntity.DescriçãoCategoria,
                NomeCategoria = categoriaEntity.NomeCategoria
            };
        }

    }
}
