using Contracts;
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
    }
}
