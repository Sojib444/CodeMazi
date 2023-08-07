namespace Services.Contracts
{
    public interface IService
    {
        ICompanyService companyService { get; set; }
        IEmployeeService employeeService { get; set; }
    }
}
