using Contract.UserRepository;

namespace Contract.UnitOfWork
{
    public interface IApplicationUnitofWork
    {
        ICompanyRepository _company { get; }
        IEmployeeRepository _employee { get; }
    }
}
