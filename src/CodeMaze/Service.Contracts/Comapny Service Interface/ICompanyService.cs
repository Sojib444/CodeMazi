using DataTransferObjects.ComapnyDTO;
using DataTransferObjects.ComapnyDTOs;
using DataTransferObjects.RequestFeatures;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        (IEnumerable<ExpandoObject>, MetaData metaData) GetAllCompanies(ComapnyParameters comapnyParameters, bool trackChange);
        CompanyDTO GetCompany(Guid Id, bool trackChange);
        CreateCompnyDTO CreateComany(CreateCompnyDTO creatCompanyDTO);
        IEnumerable<CompanyDTO> GetAllCompanyCollection(IEnumerable<Guid> ids, bool trackChage);
        (IEnumerable<CompanyDTO> comapnies, string ids) CreateCompnyCollection(IEnumerable<CreateCompnyDTO> companycllection);
        void DeleteComany(Guid companyId, bool trackChange);
        void UpdateCompany(Guid ComaPanyId,UpdateCompanyDTO updateCompanyDTO, bool trackChange);
    }
}
