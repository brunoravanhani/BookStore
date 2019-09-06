using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infra.Repository
{

    public class LivroRepository : ILivroRepository
    {
        private List<Livro> livros = new List<Livro> 
        {
            new Livro
                {
                    Titulo = "Meu Teste",
                    Autor = "Bruno Ravanhani"
                }
        };
        public Livro AtualizarLivro(Livro livro)
        {
            return livro;
        }

        public Livro BuscarLivroPorId(int idLivro)
        {
            return livros.FirstOrDefault(e => idLivro == e.IdLivro);
        }

        public IQueryable<Livro> BuscarTodosLivros()
        {
            return livros.AsQueryable();
        }

        public int DeletarLivro(int idLivro)
        {
            return idLivro;
        }

        public Livro NovoLivro(Livro livro)
        {
            livros.Add(livro);
            return livro;
        }
    }
}
