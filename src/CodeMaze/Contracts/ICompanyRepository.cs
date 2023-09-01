using Entities.Model;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllComapniesAsync(bool trackChange);
        Company GetCompany(Guid id, bool trackChange);
        void CreateCompany(Company company);
    }
}
