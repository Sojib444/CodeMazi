using Entities.Model;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies(bool trackChange);
    }
}
