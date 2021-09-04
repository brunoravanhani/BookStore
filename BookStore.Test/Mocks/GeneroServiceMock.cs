using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Test.Mocks
{
    public class GeneroServiceMock : IGeneroService
    {

        private List<GeneroViewModel> generos = new List<GeneroViewModel>
        {
            new GeneroViewModel
            {
                IdGenero = 1,
                Descricao = "Romance"
            }
        };

        public GeneroViewModel Atualizar(GeneroViewModel genero)
        {
            var index = generos.FindIndex(e => e.IdGenero == genero.IdGenero);
            generos[index] = genero;
            return genero;
        }

        public GeneroViewModel BuscarPorId(int idGenero)
        {
            var model = generos.FirstOrDefault(e => e.IdGenero == idGenero);
            return model;
        }

        public IEnumerable<GeneroViewModel> BuscarTodos()
        {
            return generos;
        }

        public GeneroViewModel Deletar(int id)
        {
            var model = generos.FirstOrDefault(e => e.IdGenero == id);
            generos.Remove(model);
            return model;
        }

        public GeneroViewModel Novo(GeneroViewModel genero)
        {
            generos.Add(genero);
            return genero;
        }
    }
}
