using Contract;
using Contract.UnitOfWork;
using Entities;
using Service.Contracts;

namespace Service
{
    public class CompnayService : ICompanyService
    {
        public CompnayService(IApplicationUnitofWork unitofWork,ILoggerManager loggerManager)
        {
            _unitofWork = unitofWork;
            LoggerManager = loggerManager;
        }

        public IApplicationUnitofWork _unitofWork { get; }
        private ILoggerManager LoggerManager { get; }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
               return _unitofWork._company.FindAll(trackChanges);

            }
            catch(Exception ex)
            {
                LoggerManager.LogError($"Somthing went wrong {ex}");

                throw;
            }

        }
    }
}
