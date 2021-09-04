using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface IAutorService
    {
        AutorViewModel Atualizar(AutorViewModel autor);
        AutorViewModel BuscarPorId(int idAutor);
        IEnumerable<AutorViewModel> BuscarTodos();
        AutorViewModel Novo(AutorViewModel autor);
        AutorViewModel Deletar(int id);
    }
}
