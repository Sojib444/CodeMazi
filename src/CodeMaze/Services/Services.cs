using Contracts;
using Contracts.Data_Shaper;
using DataTransferObjects.ComapnyDTO;
using Services.Contracts;

namespace Services
{
    public class Service : IService
    {
        private readonly IUnitofWork unitofWork;

        public ICompanyService companyService { get ; set; }
        public IEmployeeService employeeService { get; set; }
        public IDataShaper<CompanyDTO> DataShaper { get; }

        public Service(IUnitofWork unitofWork ,
            ICompanyService companyService,IEmployeeService employeeService, IDataShaper<CompanyDTO> dataShaper)
        {
            this.unitofWork = unitofWork;
            this.companyService = companyService;
            this.employeeService = employeeService;
            DataShaper = dataShaper;
        }
    }
}
