using Contract;
using LoggerService;

namespace CodeMaze.Extension_Method
{
    public static class Extension
    {
        public static void AddLoggingServce(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManger>();
        }
    }
}
