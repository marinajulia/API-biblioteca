using Biblioteca.Domain.Services.Editora.Dto;
using System.Collections.Generic;

namespace Biblioteca.Domain.Services.Editora
{
    public interface IEditoraService
    {
        IEnumerable<EditoraDto> Get();
        EditoraDto GetById(int id);
        bool Delete(int editora);
        IEnumerable<EditoraDto> GetNome(string nome);
        EditoraDto Post(EditoraDto editora);
    }
}
