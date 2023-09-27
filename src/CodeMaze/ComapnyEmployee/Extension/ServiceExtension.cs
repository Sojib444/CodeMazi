using Contracts;
using Contracts.Data_Shaper;
using DataTransferObjects.ComapnyDTO;
using LoggerService;
using Repository;
using Repository.Employeerepository;
using Repository.UnitofWork;
using Services;
using Services.Contracts;
using Services.Data_Shaping;

namespace ComapnyEmployee.Entension
{
    public static class ServiceExtension
    {
        public static void ConfigureCQRS(this IServiceCollection service)
        {
            service.AddCors(action => action.AddPolicy("poliicy", builder =>
                                   builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .WithExposedHeaders("X-Pagination")));
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
            services.AddScoped<IDataShaper<CompanyDTO>, DataShaper<CompanyDTO>>();
        }

        public static void LoggerConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRespnseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }

    }
}
