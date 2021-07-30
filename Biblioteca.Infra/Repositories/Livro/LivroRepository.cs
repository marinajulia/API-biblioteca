using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Livro;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Livro
{
    public class LivroRepository : ILivroRepository
    {
        public IEnumerable<LivroEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var livros = context.Livro;

                return livros.ToList();
            }
        }

        public bool GetByAutor(int autor)
        {
            using (var context = new ApplicationContext())
            {
                var livro = context.Livro.Any(x => x.AutorId == autor);

                if (!livro)
                    return false;
                return true;
            }
        }

        public bool GetByCategoria(int categoria)
        {
            using (var context = new ApplicationContext())
            {
                var livro = context.Livro.Any(x => x.CategoriaId == categoria);

                if (!livro)
                    return false;
                return true;
            }
        }

        public bool GetByEditora(int editora)
        {
            using (var context = new ApplicationContext())
            {
                var livro = context.Livro.Any(x => x.EditoraId == editora);

                if (!livro)
                    return false;
                return true;
            }
        }

        public LivroEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var livro = context.Livro.FirstOrDefault(x => x.LivroId == id);
                return livro;
            }
        }

        //public LivroEntity GetByIsbn(string isbn)
        //{
        //    using(var context = new ApplicationContext())
        //    {
        //        var livro = context.Livro.FirstOrDefault(x => x.ISBN == isbn);
        //        return livro;
        //    }
        //}

        public LivroEntity GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var livro = context.Livro.FirstOrDefault(x => x.Titulo.Trim().ToLower() == nome.Trim().ToLower());
                return livro;
            }
        }

        public LivroEntity Post(LivroEntity livro)
        {
            using (var context = new ApplicationContext())
            {
                context.Livro.Add(livro); //para put seria update
                context.SaveChanges();
                return livro;
            }
        }

        public LivroEntity Put(LivroEntity livroEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.Livro.Update(livroEntity);
                context.SaveChanges();
                return livroEntity;
            }
        }
    }
}
