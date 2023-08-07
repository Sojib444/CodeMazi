using Entities.Model;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IQueryable<Company>> GetAllComapniesAsync(bool trackChange);
    }
}
