using Contracts;
using Entities.Model;
using Services.Contracts;

namespace Services
{
    public class ComapnyService : ICompanyService
    {
        private readonly IUnitofWork unitofWork;

        public ComapnyService(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public  IEnumerable<Company> GetAllCompanies(bool trackChange)
        {
            try
            {
                return unitofWork.companyRepository.GetAllComapniesAsync(trackChange);
            }
            catch(Exception ex)
            {
                throw ;
            }
        }
    }
}
