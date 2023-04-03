using Contract.UnitOfWork;
using Contract.UserRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Persistance.UnitOfWorks
{
    public class ApplicationUnitofWork :UnitOfwork,IApplicationUnitofWork
    {
        public ApplicationUnitofWork(ApplicationDbContext context,
            ICompanyRepository companyRepository,
            IEmployeeRepository employeeRepository) : base( context)
        {
            _company = companyRepository;
            _employee = employeeRepository;
        }

        public ICompanyRepository _company { get; }

        public IEmployeeRepository _employee { get; }
    }
}
