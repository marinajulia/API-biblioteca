using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Editora
{
    public interface IEditoraRepository
    {
        IEnumerable<EditoraEntity> Get();
        IEnumerable<EditoraEntity> Get(string nome);
        EditoraEntity GetById(int id);
        EditoraEntity Post(EditoraEntity editoraEntity);
        EditoraEntity GetByName(string nome);
        bool Delete(EditoraEntity editoraEntity);


    }
}
