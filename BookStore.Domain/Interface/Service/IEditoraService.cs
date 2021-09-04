using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface IEditoraService
    {
        EditoraViewModel Atualizar(EditoraViewModel editora);
        EditoraViewModel BuscarPorId(int idEditora);
        IEnumerable<EditoraViewModel> BuscarTodos();
        EditoraViewModel Novo(EditoraViewModel editora);
        EditoraViewModel Deletar(int id);
    }
}
