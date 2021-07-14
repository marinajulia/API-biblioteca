using Biblioteca.Domain.Services.Entidades;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Editora
{
    public interface IEditoraRepository
    {
        IEnumerable<EditoraEntity> Get();
        EditoraEntity GetById(int id);
        EditoraEntity Post(EditoraEntity editoraEntity);
        EditoraEntity GetByName(string nome);

    }
}
