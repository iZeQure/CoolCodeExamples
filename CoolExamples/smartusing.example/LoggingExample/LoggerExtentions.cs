using Microsoft.Extensions.Logging;
using System;

namespace smartusing.example.LoggingExample
{
    public static class LoggerExtentions
    {
        public static IDisposable TimedOperation<T>(this ILogger<T> logger, LogLevel logLevel, string message, params object?[] args)
            => logLevel switch
            {
                LogLevel.Debug => new TimedLogOperation<T>(logger, LogLevel.Debug, message, args),
                LogLevel.Information => new TimedLogOperation<T>(logger, LogLevel.Debug, message, args),
                LogLevel.Warning => new TimedLogOperation<T>(logger, LogLevel.Debug, message, args),
                LogLevel.Error => new TimedLogOperation<T>(logger, LogLevel.Debug, message, args),
                LogLevel.Critical => new TimedLogOperation<T>(logger, LogLevel.Debug, message, args),
                _ => new TimedLogOperation<T>(logger, LogLevel.None, message, args),
            };
    }
}
