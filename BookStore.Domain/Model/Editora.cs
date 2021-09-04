using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Model
{
    public partial class Editora
    {
        public Editora()
        {
            Livro = new HashSet<Livro>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livro { get; set; }
    }
}
