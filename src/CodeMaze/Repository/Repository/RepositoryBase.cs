using Contract;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq.Expressions;

namespace Persistance.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _set = _applicationDbContext.Set<T>();
        }

        protected ApplicationDbContext _applicationDbContext { get; }
        private DbSet<T> _set { get; }

        public void Create(T entity)
        {
            _set.Add(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if(!trackChanges)
            {
                return _set.AsNoTracking();
            }
            else
            {
                return _set.AsTracking();
            }
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }
    }
}
