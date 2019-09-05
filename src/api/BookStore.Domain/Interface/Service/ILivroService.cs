using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface ILivroService
    {
        IEnumerable<LivroViewModel> BuscarTodosLivros();
    }
}
