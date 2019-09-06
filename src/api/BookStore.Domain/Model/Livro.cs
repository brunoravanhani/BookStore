using System;

namespace BookStore.Domain.Model
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public string ImagemCapa { get; set; }
        public string Link { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }
        public int IdEditora { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
    }
}