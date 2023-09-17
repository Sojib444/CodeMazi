using Contracts;
using DataTransferObjects.RequestFeatures;
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

        public IEnumerable<T> FinaAll(RequestParameters requestParameters, bool trackChange)
        {
            //return !trackChange ? dbSet.Skip((requestParameters.pageNumber - 1) * requestParameters.pageSize).
            //    Take(requestParameters.pageSize)
            //    .AsNoTracking() : dbSet.Skip((requestParameters.pageNumber - 1) * requestParameters.pageSize).
            //    Take(requestParameters.pageSize);

            return !trackChange ? dbSet.ToList() 
                : dbSet.ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange)
        {
            return !trackChange ? dbSet.Where(expression).AsNoTracking().ToList() :
                dbSet.Where(expression).ToList();
        }
    }
}
