using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Domain.Interface.Service
{
    public interface ILivroService
    {
        IEnumerable<LivroViewModel> BuscarTodosLivros();
        LivroViewModel BuscarLivroPorId(int idLivro);
        LivroViewModel NovoLivro(LivroViewModel livro);
        LivroViewModel AtualizarLivro(LivroViewModel livro);
        int DeletarLivro(int idLivro);

    }
}
