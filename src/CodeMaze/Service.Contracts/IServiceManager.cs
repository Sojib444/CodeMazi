namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICompanyService companyService { get; set; }
        IEmployeeService IEmployeeService { get; set; }
    }
}
