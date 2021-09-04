using System.Collections.Generic;

namespace BookStore.Domain.ViewModel
{
    public class EditoraViewModel
    {
        public EditoraViewModel()
        {
            Livro = new HashSet<LivroViewModel>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<LivroViewModel> Livro { get; set; }
    }
}
