using DataTransferObjects.ComapnyDTO;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDTO> GetAllCompanies(bool trackChange);
    }
}
