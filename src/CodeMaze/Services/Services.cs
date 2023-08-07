using Contracts;
using Services.Contracts;

namespace Services
{
    public class Service : IService
    {
        private readonly IUnitofWork unitofWork;

        public ICompanyService companyService { get ; set; }
        public IEmployeeService employeeService { get; set; }

        public Service(IUnitofWork unitofWork ,
            ICompanyService companyService,IEmployeeService employeeService)
        {
            this.unitofWork = unitofWork;
            this.companyService = companyService;
            this.employeeService = employeeService;
        }
    }
}
