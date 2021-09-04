using System;
using System.Linq;

namespace BookStore.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> BuscarTodos();
        TEntity BuscarPorId(int id);
        TEntity Novo(TEntity entity);
        TEntity Atualizar(TEntity entity);
        TEntity Deletar(TEntity entity);
        void SaveChanges();
    }
}
