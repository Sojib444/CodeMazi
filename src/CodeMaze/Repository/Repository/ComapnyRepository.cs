using Contract.UserRepository;
using Entities;
using Repository.Context;

namespace Persistance.Repository
{
    public class ComapnyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public ComapnyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges)
                 .OrderBy(c => c.Name)
                 .ToList();

        }
    }
}
