using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class ServiceEntension
    {
        public static void UnitofWork(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<RepositoryContext>();
        }
    }
}
