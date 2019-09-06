using BookStore.Domain.Interface.Repository;
using BookStore.Domain.Model;
using BookStore.Infra.Context;

namespace BookStore.Infra.Repository
{
    public class EditoraRepository : RepositoryBase<Editora>, IEditoraRepository
    {
        public EditoraRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
