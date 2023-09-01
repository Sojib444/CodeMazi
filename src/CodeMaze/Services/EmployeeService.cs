using AutoMapper;
using Contracts;
using DataTransferObjects.ComapnyDTO;
using Entities.ErrorModel;
using Services.Contracts;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationUnitofWork unitofWork;
        private readonly IMapper mapper;

        public EmployeeService(IApplicationUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployessDto(Guid ComapanyId, bool trackChange)
        {
            var employees = unitofWork.employeeRepository.GetAllEmployees(ComapanyId, trackChange);

            if (employees == null)
            {
                throw new EmployeesNotFoundException(ComapanyId);
            }

            var employeesDto = mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return employeesDto;
        }

        public EmployeeDTO GetEmployesDto(Guid ComapanyId, Guid employeeId, bool trackChange)
        {
            var employee = unitofWork.employeeRepository.GetEmployee(ComapanyId, employeeId, trackChange)
            .FirstOrDefault();

            if (employee == null)
            {
                throw new EmployeesNotFoundException(ComapanyId);
            }

            var employeeDto = mapper.Map<EmployeeDTO>(employee);

            return employeeDto;
        }
    }
}
