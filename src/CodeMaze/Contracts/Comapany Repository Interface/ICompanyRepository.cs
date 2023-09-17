using DataTransferObjects.RequestFeatures;
using Entities.Model;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface ICompanyRepository
    {
        PagedList<Company> GetAllComapniesAsync(ComapnyParameters requestParameters, bool trackChange);
        Company GetCompany(Guid id, bool trackChange);
        void CreateCompany(Company company);
        List<Company> GetAllCompanyCollection(IEnumerable<Guid> ids, bool trackChage);
        void DeleteComapny(Company company,bool trackChange);
        Company UpdateCompany(Guid companyID, bool trackChange);
    }
}
