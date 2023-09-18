using AutoMapper;
using Contracts;
using Contracts.Data_Shaper;
using DataTransferObjects.EmployeeDTO;
using Entities.ErrorModel;
using Entities.Model;
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

        public EmployeeDTO CreateEmployee(Guid companyId, EmployeeForCompanyDTO employee, bool trackChange)
        {
            var company = unitofWork.companyRepository.GetCompany(companyId, trackChange);

            if(company == null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var result = mapper.Map<Employee>(employee);
            result.Id = Guid.NewGuid();

            unitofWork.employeeRepository.EmployeeForCompany(companyId, result);
            unitofWork.SaveChage();
            unitofWork.Dispose();

            var response = mapper.Map<EmployeeDTO>(result);

            return response;
            
        }

        public void DeleteEmployee(Guid companyID, Guid employeeID,bool trackChange)
        {
            var comapny = unitofWork.companyRepository.GetCompany(companyID, trackChange);

            if(comapny == null)
            {
                throw new CompanyNotFoundException(companyID);
            }

            var employee = unitofWork.employeeRepository.GetEmployee(companyID,employeeID,trackChange).SingleOrDefault();

            if(employee == null)
            {
                throw new EmployeesNotFoundException(employeeID);
            }

            unitofWork.employeeRepository.DeleteEmployee(employee);
            unitofWork.SaveChage();
            unitofWork.Dispose();
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

        public (UpdateEmployee employeeToPatch, Employee employeeEntity)GetEmployeeForPatch(Guid companyId, Guid id,
                                                                   bool compTrackChanges, bool empTrackChanges)
        {
            var company = unitofWork.companyRepository.GetCompany(companyId, compTrackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = unitofWork.employeeRepository.GetEmployee(companyId, id,
            empTrackChanges).SingleOrDefault();

            if (employeeEntity is null)
                throw new EmployeesNotFoundException(companyId);

            var employeeToPatch = mapper.Map<UpdateEmployee>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public void SaveChangesForPatch(UpdateEmployee employeeToPatch, Employee employeeEntity)
        {
            mapper.Map(employeeToPatch, employeeEntity);

            unitofWork.SaveChage();
            unitofWork.Dispose();
        }

    }
}
