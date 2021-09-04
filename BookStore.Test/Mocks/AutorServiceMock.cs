using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Test.Mocks
{
    public class AutorServiceMock : IAutorService
    {

        private List<AutorViewModel> autores = new List<AutorViewModel>
        {
            new AutorViewModel
            {
                IdAutor = 1,
                Nome = "Paulo Coelho"
            }
        };

        public AutorViewModel Atualizar(AutorViewModel autor)
        {
            var index = autores.FindIndex(e => e.IdAutor == autor.IdAutor);
            autores[index] = autor;
            return autor;
        }

        public AutorViewModel BuscarPorId(int idAutor)
        {
            var model = autores.FirstOrDefault(e => e.IdAutor == idAutor);
            return model;
        }

        public IEnumerable<AutorViewModel> BuscarTodos()
        {
            return autores;
        }

        public AutorViewModel Deletar(int id)
        {
            var model = autores.FirstOrDefault(e => e.IdAutor == id);
            autores.Remove(model);
            return model;
        }

        public AutorViewModel Novo(AutorViewModel autor)
        {
            autores.Add(autor);
            return autor;
        }
    }
}
