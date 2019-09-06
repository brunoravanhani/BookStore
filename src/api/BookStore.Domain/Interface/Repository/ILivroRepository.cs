using BookStore.Domain.Model;
using System.Linq;

namespace BookStore.Domain.Interface.Repository
{
    public interface ILivroRepository
    {
        IQueryable<Livro> BuscarTodosLivros();
        Livro BuscarLivroPorId(int idLivro);
        Livro NovoLivro(Livro livro);
        Livro AtualizarLivro(Livro livro);
        int DeletarLivro(int idLivro);
    }
}
