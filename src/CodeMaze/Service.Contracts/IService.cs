namespace Service.Contracts
{
    public interface IService
    {
        ICompanyService companyService { get; set; }
        IEmployeeService employeeService { get; set; }
    }
}
