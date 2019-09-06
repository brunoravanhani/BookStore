using System.Collections.Generic;

namespace BookStore.Domain.Model
{
    public partial class Autor
    {
        public Autor()
        {
            Livro = new HashSet<Livro>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livro { get; set; }
    }
}
