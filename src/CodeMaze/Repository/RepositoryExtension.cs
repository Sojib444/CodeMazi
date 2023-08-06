using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class RepositoryExtension
    {
        public static void RepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<RepositoryContext>();
        }
    }
}
