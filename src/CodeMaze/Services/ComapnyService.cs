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

        public ComapnyService(IUnitofWork unitofWork,ILoggerManager loggerManager)
        {
            this.unitofWork = unitofWork;
            this.loggerManager = loggerManager;
        }

        public  IEnumerable<CompanyDTO> GetAllCompanies(bool trackChange)
        {
            try
            {
                var companies = unitofWork.companyRepository.GetAllComapniesAsync(trackChange);

                var companiesDto = companies.Select(e => new CompanyDTO(e.Id,e.Name?? "" ,string.Join(" ",e.Address,e.Country)));

                return companiesDto;
                
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
