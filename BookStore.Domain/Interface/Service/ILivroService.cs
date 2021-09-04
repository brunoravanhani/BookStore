using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface ILivroService
    {
        IEnumerable<LivroViewModel> BuscarTodos();
        LivroViewModel BuscarPorId(int idLivro);
        LivroViewModel Novo(LivroViewModel livro);
        LivroViewModel Atualizar(LivroViewModel livro);
        LivroViewModel Deletar(int id);

    }
}
