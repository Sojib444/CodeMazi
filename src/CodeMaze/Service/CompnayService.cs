using Contract.UnitOfWork;
using Service.Contracts;

namespace Service
{
    public class CompnayService : ICompanyService
    {
        public CompnayService(IApplicationUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IApplicationUnitofWork _unitofWork { get; }
    }
}
