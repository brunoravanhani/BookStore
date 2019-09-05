using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using System.Collections.Generic;

namespace BookStore.Service
{
    public class LivroService : ILivroService
    {
        public IEnumerable<LivroViewModel> BuscarTodosLivros()
        {
            return new List<LivroViewModel>
            {
                new LivroViewModel
                {
                    Autor = "TESTE",
                    Titulo = "TESTE"
                }
            };
        }
    }
}
