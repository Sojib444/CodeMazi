using DataTransferObjects.ComapnyDTO;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployessDto(Guid ComapanyId, bool trackChange);
        EmployeeDTO GetEmployesDto(Guid ComapanyId, Guid employeeId, bool trackChange);
    }
}
