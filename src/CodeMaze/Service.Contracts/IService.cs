namespace Service.Contracts
{
    public interface IService
    {
        ICompanyService companyService { get; set; }
        IEmployeeService IEmployeeService { get; set; }
    }
}
