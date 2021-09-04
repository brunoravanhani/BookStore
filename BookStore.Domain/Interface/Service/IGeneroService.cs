using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface IGeneroService
    {
        GeneroViewModel Atualizar(GeneroViewModel genero);
        GeneroViewModel BuscarPorId(int idGenero);
        IEnumerable<GeneroViewModel> BuscarTodos();
        GeneroViewModel Novo(GeneroViewModel genero);
        GeneroViewModel Deletar(int id);
    }
}
