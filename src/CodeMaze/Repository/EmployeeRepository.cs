using Contracts;
using Entities.Model;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public IEnumerable<Employee> GetAllEmployees(Guid comapnyId, bool trackChange)
        {
            return FindByCondition(employee => employee.CompanyId.Equals(comapnyId), false)
                .OrderBy(emp => emp.Name).ToList();
        }

        public IEnumerable<Employee> GetEmployee(Guid CompanyId,Guid employeeId, bool trackChange)
        {
            return FindByCondition(emp => emp.CompanyId.Equals(CompanyId) 
                                && emp.Id == employeeId, false).ToList();
        }
    }
}
