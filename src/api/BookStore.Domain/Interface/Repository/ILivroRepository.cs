using BookStore.Domain.Model;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Repository
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> BuscarTodosLivros();
    }
}
