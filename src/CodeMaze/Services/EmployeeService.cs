using Contracts;
using Services.Contracts;

namespace Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitofWork unitofWork;

        public EmployeeService(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
    }
}
