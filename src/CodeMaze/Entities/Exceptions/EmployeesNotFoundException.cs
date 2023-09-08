namespace Entities.ErrorModel
{
    public class EmployeesNotFoundException : NotFoundException
    {
        public EmployeesNotFoundException(Guid CompanyId) : base($"There are no Employess in this comapany. Company Id {CompanyId} ")
        {
        }
    }
}
