using Contract;
using Contract.UnitOfWork;
using Contract.UserRepository;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.Repository;
using Persistance.UnitOfWorks;
using Repository.Context;
using Service;
using Service.Contracts;

namespace CodeMaze.Extension_Method
{
    public static class Extension
    {
        public static void AddLoggingServce(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManger>();
        }

        public static void AddRepositoryAndUnitofWork(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("connectionstring")));

            services.AddScoped<IApplicationUnitofWork, ApplicationUnitofWork>();
            services.AddScoped<IUnitofWork, UnitOfwork>();
            services.AddScoped<ICompanyRepository, ComapnyRepository>();
            services.AddScoped<ICompanyService, CompnayService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
