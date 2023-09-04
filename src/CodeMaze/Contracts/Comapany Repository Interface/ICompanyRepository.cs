using Entities.Model;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllComapniesAsync(bool trackChange);
        Company GetCompany(Guid id, bool trackChange);
        void CreateCompany(Company company);
        List<Company> GetAllCompanyCollection(IEnumerable<Guid> ids, bool trackChage);
        void DeleteComapny(Company company,bool trackChange);
    }
}
