using Contracts;
using Entities.Model;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<Company> GetAllComapniesAsync(bool trackChange)
        {
            return  FinaAll(trackChange).OrderBy(e => e.Name).ToList();
        }
    }
}
