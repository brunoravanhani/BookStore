using System.Linq;
using BookStore.Domain.Interface.Repository;
using BookStore.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infra.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BookStoreContext Contexto;
        protected readonly DbSet<TEntity> Entidade;

        public RepositoryBase(BookStoreContext context)
        {
            Contexto = context;
            Entidade = Contexto.Set<TEntity>();
        }

        public IQueryable<TEntity> BuscarTodos()
        {
            return Entidade.AsQueryable();
        }

        public TEntity BuscarPorId(int id)
        {
            return Entidade.Find(id);
        }

        public TEntity Novo(TEntity entity)
        {
            Entidade.Add(entity);
            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            Entidade.Update(entity);
            return entity;
        }
        public TEntity Deletar(TEntity entity)
        {
            Entidade.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
