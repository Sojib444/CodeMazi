using DataTransferObjects.ComapnyDTO;
using DataTransferObjects.ComapnyDTOs;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDTO> GetAllCompanies(bool trackChange);
        CompanyDTO GetCompany(Guid Id, bool trackChange);
        CreateCompnyDTO CreateComany(CreateCompnyDTO creatCompanyDTO);
    }
}
