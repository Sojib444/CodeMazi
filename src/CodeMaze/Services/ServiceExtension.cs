using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;

namespace Services
{
    public static class ServiceExtension
    {
        public static void ServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, ComapnyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IService, Service>();
        }
    }
}
