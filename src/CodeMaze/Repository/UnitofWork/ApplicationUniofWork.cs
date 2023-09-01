using Contracts;

namespace Repository.UnitofWork
{
    public class ApplicationUniofWork : UnitofWork, IApplicationUnitofWork
    {
        public ICompanyRepository companyRepository { get; }
        public IEmployeeRepository employeeRepository { get; }

        public ApplicationUniofWork(ICompanyRepository companyRepository,
            IEmployeeRepository employeeRepository, RepositoryContext repositoryContext) : base(repositoryContext)
        {
            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;
        }
    }
}
