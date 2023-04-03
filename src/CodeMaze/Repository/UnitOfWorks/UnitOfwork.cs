using Contract.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Persistance.UnitOfWorks
{
    public class UnitOfwork : IUnitofWork
    {
        public UnitOfwork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext _dbContext { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Savechange()
        {
            _dbContext.SaveChanges();
        }
    }
}
