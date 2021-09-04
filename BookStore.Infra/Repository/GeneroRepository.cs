using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        public GeneroRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
