using System.Collections.Generic;

namespace BookStore.Domain.ViewModel
{
    public class AutorViewModel
    {
        public AutorViewModel()
        {
            Livro = new HashSet<LivroViewModel>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<LivroViewModel> Livro { get; set; }
    }
}
