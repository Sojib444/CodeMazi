using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(Guid comapnyId , bool trackChange);
        IEnumerable<Employee> GetEmployee(Guid CompanyId,Guid employeeID, bool trackChange);
        void EmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
