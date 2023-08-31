using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _repositoryContext;
        private DbSet<T> dbSet;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            dbSet = _repositoryContext.Set<T>();           
        }
        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public IEnumerable<T> FinaAll(bool trackChange)
        {
            return dbSet.ToList();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange)
        {
            return !trackChange ? dbSet.Where(expression).AsNoTracking() :
                dbSet.Where(expression);
        }
    }
}
