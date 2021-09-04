using System.Collections.Generic;

namespace BookStore.Domain.ViewModel
{
    public class GeneroViewModel
    {
        public GeneroViewModel()
        {
            Livro = new HashSet<LivroViewModel>();
        }

        public int IdGenero { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LivroViewModel> Livro { get; set; }
    }
}
