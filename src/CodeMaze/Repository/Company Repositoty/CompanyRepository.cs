using Contracts;
using DataTransferObjects.RequestFeatures;
using Entities.Model;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public IEnumerable<Company> GetAllComapniesAsync(RequestParameters requestParameters, bool trackChange)
        {
            return FinaAll(requestParameters,trackChange);
        }

        public Company GetCompany(Guid id, bool trackChange)
        {
           return FindByCondition(company => company.Id.Equals(id), false).SingleOrDefault();
        }

        public List<Company> GetAllCompanyCollection(IEnumerable<Guid> ids, bool trackChage)
        {
           return FindByCondition(x => ids.Contains(x.Id), trackChage).ToList();
        }

        public void DeleteComapny(Company company, bool trackChange)
        {
            Delete(company);
        }

        public Company UpdateCompany(Guid companyID, bool trackChange)
        {
            return FindByCondition(emp => emp.Id.Equals(companyID), trackChange).SingleOrDefault(); 
        }
    }
}
