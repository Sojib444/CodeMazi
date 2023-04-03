using Contract;
using Contract.UnitOfWork;
using Contract.UserRepository;
using LoggerService;
using Persistance.UnitOfWorks;
using Persistance.UserRepository;
using Repository.Context;

namespace CodeMaze.Extension_Method
{
    public static class Extension
    {
        public static void AddLoggingServce(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManger>();
        }

        public static void AddRepositoryAndUnitofWork(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUnitofWork, ApplicationUnitofWork>();
            services.AddScoped<IUnitofWork, UnitOfwork>();
            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
