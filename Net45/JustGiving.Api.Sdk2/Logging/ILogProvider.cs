using System;

namespace JustGiving.Api.Sdk2.Logging
{
    /// <summary>
    /// Implement this interface to replace the default logging infrastructure with your preferred logging solution.
    /// </summary>
    public interface ILogProvider
    {
        void Warn(string message);
        void Info(string message);
        void Debug(string message);
        void Error(string message, Exception ex = null);
    }
}