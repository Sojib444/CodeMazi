using DataTransferObjects.EmployeeDTO;

namespace DataTransferObjects.ComapnyDTO
{
    public record UpdateCompanyDTO(string name, string address, string country, IEnumerable<EmployeeForCompanyDTO> employees = null);
}
