using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using System.Collections.Generic;

namespace BookStore.Infra.Repository
{
    public class LivroRepository : ILivroRepository
    {
        public IEnumerable<Livro> BuscarTodosLivros()
        {
            return new List<Livro>
            {
                new Livro
                {
                    Titulo = "Meu Teste",
                    Autor = "Bruno Ravanhani"
                }
            };
        }
    }
}
