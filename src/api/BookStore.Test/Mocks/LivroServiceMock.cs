using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Test.Mocks
{
    public class LivroServiceMock : ILivroService
    {

        private List<LivroViewModel> livros = new List<LivroViewModel>
        {
            new LivroViewModel
            {
                IdLivro = 1,
                Titulo = "MindSet"
            }
        };

        public LivroViewModel Atualizar(LivroViewModel livro)
        {
            var index = livros.FindIndex(e => e.IdLivro == livro.IdLivro);
            livros[index] = livro;
            return livro;
        }

        public LivroViewModel BuscarPorId(int idLivro)
        {
            var model = livros.FirstOrDefault(e => e.IdLivro == idLivro);
            return model;
        }

        public IEnumerable<LivroViewModel> BuscarTodos()
        {
            return livros;
        }

        public LivroViewModel Deletar(int id)
        {
            var model = livros.FirstOrDefault(e => e.IdLivro == id);
            livros.Remove(model);
            return model;
        }

        public LivroViewModel Novo(LivroViewModel livro)
        {
            livros.Add(livro);
            return livro;
        }
    }
}
