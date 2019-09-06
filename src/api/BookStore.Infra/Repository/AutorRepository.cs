using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
