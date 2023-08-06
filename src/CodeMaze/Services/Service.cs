using Contracts;
using Service.Contracts;

namespace Services
{
    public class Service : IService
    {
        private readonly IUnitofWork unitofWork;
        public ICompanyService companyService { get ; set; }
        public IEmployeeService IEmployeeService { get; set; }

        public Service(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
    }
}
