using Entities.Model;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(Guid comapnyId , bool trackChange);
        IEnumerable<Employee> GetEmployee(Guid CompanyId,Guid employeeID, bool trackChange);
        void EmployeeForCompany(Guid companyId, Employee employee);
    }
}
