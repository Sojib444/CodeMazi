using DataTransferObjects.EmployeeDTO;

namespace DataTransferObjects.ComapnyDTOs
{
    public record CreateCompnyDTO(string name, string address,string country,IEnumerable<EmployeeForCompanyDTO> employees = null);
}
