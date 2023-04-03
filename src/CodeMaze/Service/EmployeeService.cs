using Contract.UnitOfWork;
using Service.Contracts;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IApplicationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IApplicationUnitofWork _unitofWork { get; }
    }
}
