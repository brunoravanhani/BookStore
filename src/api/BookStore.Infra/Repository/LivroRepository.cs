using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{

    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
