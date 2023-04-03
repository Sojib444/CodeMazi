using Contract.UserRepository;
using Entities;
using Persistance.Repository;
using Repository.Context;


namespace Persistance.UserRepository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
