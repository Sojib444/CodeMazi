using DataTransferObjects.EmployeeDTO;
using Entities.Model;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployessDto(Guid ComapanyId, bool trackChange);
        EmployeeDTO GetEmployesDto(Guid ComapanyId, Guid employeeId, bool trackChange);
        EmployeeDTO CreateEmployee(Guid companyId, EmployeeForCompanyDTO employee,bool trackChange);
        void DeleteEmployee(Guid companyID,Guid employeeID,bool trackChange);
        (UpdateEmployee employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(
            Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(UpdateEmployee employeeToPatch, Employee employeeEntity);
    }
}
