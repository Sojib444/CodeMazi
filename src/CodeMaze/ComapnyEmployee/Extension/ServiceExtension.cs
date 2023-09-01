using Contracts;
using LoggerService;
using Repository;
using Repository.Employeerepository;
using Repository.UnitofWork;
using Services;
using Services.Contracts;

namespace ComapnyEmployee.Entension
{
    public static class ServiceExtension
    {
        public static void ConfigureCQRS(this IServiceCollection service)
        {
            service.AddCors(action => action.AddPolicy("poliicy", builder =>
                                   builder.AllowAnyOrigin().
                                   AllowAnyHeader()));
        }

        public static void ConfigureCQRS1(this IServiceCollection service)
        {
            service.AddCors(action => action.AddPolicy("poliicy", builder =>
                                   builder.AllowAnyOrigin().
                                   AllowAnyHeader()));
        }

        public static void RepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IRepositoryContext, RepositoryContext>();
            services.AddScoped<IApplicationUnitofWork, ApplicationUniofWork>();
        }

        public static void ServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, ComapnyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IService, Service>();
        }

        public static void LoggerConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
