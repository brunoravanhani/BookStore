using System.Collections.Generic;

namespace BookStore.Domain.Model
{
    public partial class Genero
    {
        public Genero()
        {
            Livro = new HashSet<Livro>();
        }

        public int IdGenero { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Livro> Livro { get; set; }
    }
}
