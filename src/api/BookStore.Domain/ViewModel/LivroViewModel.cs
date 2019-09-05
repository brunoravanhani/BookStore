using System;

namespace BookStore.Domain.ViewModel
{
    public class LivroViewModel
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Descricao { get; set; }
        public string Sinopse { get; set; }
        public string ImagemCapa { get; set; }
        public string Link { get; set; }
    }
}
