namespace Mathematics.Infrastructure.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ILogger
    {
        void AuthenticationError(string msg, object eventSource, string userName);
        void Error(string message, object eventSource, Exception exception, IEnumerable<string> customDetails = null);

        void Info(string message, object eventSource, int eventCode = 100001);
    }
}