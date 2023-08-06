using Contracts;

namespace Repository
{
    public class UnitofWork : IUnitofWork
    {
        public ICompanyRepository companyRepository { get ; set ; }
        public IEmployeeRepository employeeRepository { get; set; }
        private RepositoryContext repositoryContext { get; set; }

        public UnitofWork(ICompanyRepository companyRepository, 
            IEmployeeRepository employeeRepository, RepositoryContext repositoryContext)
        {
            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;
            this.repositoryContext = repositoryContext;
        }

        public async Task SaveChage()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
