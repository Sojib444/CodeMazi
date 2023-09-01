namespace Contracts
{
    public interface IApplicationUnitofWork : IUnitofWork
    {
        public ICompanyRepository companyRepository { get;  }
        public IEmployeeRepository employeeRepository { get; }
    }
}
