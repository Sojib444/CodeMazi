namespace Contracts
{
    public interface IUnitofWork
    {
        ICompanyRepository companyRepository { get; set; }  
        IEmployeeRepository employeeRepository { get; set; }
        Task SaveChage();        
    }
}
