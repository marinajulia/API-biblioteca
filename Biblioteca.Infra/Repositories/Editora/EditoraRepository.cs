using Biblioteca.Domain.Services.Editora;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Infra.Repositories.Editora
{
    public class EditoraRepository : IEditoraRepository
    {
        public bool Delete(EditoraEntity editoraEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.Editora.Remove(editoraEntity);
                context.SaveChanges();

                return true;
            }
        }

        public IEnumerable<EditoraEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var editoras = context.Editora;
                return editoras.ToList();
            }
        }

        public EditoraEntity GetById(int id)
        {
            using(var context = new ApplicationContext())
            {
                var editora = context.Editora.FirstOrDefault(x => x.EditoraId == id);
                return editora;
            }
        }

        public EditoraEntity GetByName(string nome)
        {
            using(var context = new ApplicationContext())
            {
                var editora = context.Editora.FirstOrDefault(x => x.NomeEditora.Trim().ToLower() == nome.Trim().ToLower());
                return editora;
            }
        }

        public EditoraEntity Post(EditoraEntity editora)
        {
            using(var context = new ApplicationContext())
            {
                context.Editora.Add(editora);
                context.SaveChanges();
                return editora;
            }
        }

    }
}
