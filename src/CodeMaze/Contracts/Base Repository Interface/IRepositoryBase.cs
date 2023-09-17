using DataTransferObjects.RequestFeatures;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FinaAll(RequestParameters requestParameters, bool trackChange);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChange);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
