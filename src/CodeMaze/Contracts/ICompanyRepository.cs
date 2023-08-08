using Entities.Model;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllComapniesAsync(bool trackChange);
    }
}
