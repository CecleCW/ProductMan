using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProductMan.Utilities
{
    public interface ILogger : IDisposable
    {
        void Error(string message);
        void Info(string message);
        void WriteEventLog(string message, EventLogEntryType eventType);
    }
}
