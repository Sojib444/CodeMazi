using Contract;
using NLog;
using ILogger = NLog.ILogger;

namespace LoggerService
{
    public class LoggerManger : ILoggerManager
    {

        public static ILogger Logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => Logger.Debug(message);

        public void LogError(string message) => Logger.Error(message);

        public void LogInfo(string message) => Logger.Info(message);

        public void LogWarn(string message) => Logger.Warn(message);
    }
}