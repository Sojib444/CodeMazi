using Contracts;
using Serilog;
using Serilog.Events;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {

        public void LogDebug(string message)
        {
            Log.Write(LogEventLevel.Debug,message);
        }

        public void LogError(string message)
        {
            Log.Write(LogEventLevel.Error, message);
        }

        public void LogInfo(string message)
        {
            Log.Write(LogEventLevel.Information, message);
        }

        public void LogWarn(string message)
        {
            Log.Write(LogEventLevel.Warning, message);
        }
    }
}