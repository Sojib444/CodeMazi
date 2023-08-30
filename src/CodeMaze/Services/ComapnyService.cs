using AutoMapper;
using Contracts;
using DataTransferObjects.ComapnyDTO;
using Entities.Model;
using Services.Contracts;

namespace Services
{
    public class ComapnyService : ICompanyService
    {
        private readonly IUnitofWork unitofWork;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        public ComapnyService(IUnitofWork unitofWork,ILoggerManager loggerManager,IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        public  IEnumerable<CompanyDTO> GetAllCompanies(bool trackChange)
        {
            var companies = unitofWork.companyRepository.GetAllComapniesAsync(trackChange);

            // var companiesDto = companies.Select(e =>
            // new CompanyDTO(e.Id,e.Name?? "" ,string.Join(" ",e.Address,e.Country)));
            throw new Exception();
                var companiesDto = mapper.Map<IEnumerable<CompanyDTO>>(companies);

                return companiesDto;        
        }
    }
}
