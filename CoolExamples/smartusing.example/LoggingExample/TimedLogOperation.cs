using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace smartusing.example.LoggingExample
{
    public class TimedLogOperation<T> : IDisposable
    {
        private readonly ILogger<T> _logger;
        private readonly LogLevel _logLevel;
        private readonly string _message;
        private readonly object?[] _args;
        private readonly Stopwatch _stopwatch;

        public TimedLogOperation(ILogger<T> logger, LogLevel logLevel, string message, object[] args)
        {
            _logger = logger;
            _logLevel = logLevel;
            _message = message;
            _args = args;

            _stopwatch = Stopwatch.StartNew();
        }

        void IDisposable.Dispose()
        {
            _stopwatch.Stop();
            _logger.Log(
                logLevel: _logLevel,
                message: $"{_message} completed in {_stopwatch.ElapsedMilliseconds}ms",
                args: _args);

            GC.SuppressFinalize(this);
        }
    }
}
