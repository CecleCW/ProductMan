using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace ProductMan.Utilities
{
    public class LoggerBase : ILogger
    {
        protected static LoggerBase instance;
        protected static volatile object syncRoot = new object();

        protected const string LOGFILE = "c:\\SYD\\Log\\{0}Log.txt";
        protected string eventSource;
        protected string logName;
        protected StreamWriter writer;

        private LoggerBase()
        {
            try
            {
                string path = "c:\\SYD\\Log\\LoggerBaseLog.txt";
                eventSource = "LoggerBase";
                Assembly asm = Assembly.GetEntryAssembly();
                if (asm != null)
                {
                    path = string.Format(LOGFILE, asm.GetName().Name);
                    eventSource = asm.GetName().Name;
                }
                logName = "Application";
                string folder = Path.GetDirectoryName(path);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                writer = new StreamWriter(path, true, Encoding.Default);
            }
            catch { }
        }

        public static LoggerBase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LoggerBase();
                    }
                }

                return instance;
            }
        }

        #region ILogger Members

        public void Error(string message)
        {
            WriteText("<Error> " + message);
        }

        public void Info(string message)
        {
            WriteText("<Info>  " + message);
        }

        public void WriteEventLog(string message, EventLogEntryType eventType)
        {
            try
            {
                if (!EventLog.SourceExists(eventSource))
                {
                    EventLog.CreateEventSource(eventSource, logName);
                }

                EventLog msg = new EventLog(logName);
                msg.Source = eventSource;
                msg.WriteEntry(message, eventType);
            }
            catch { }
        }

        #endregion

        private void WriteText(string message)
        {
            try
            {
                writer.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), message));
                writer.Flush();
            }
            catch { }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (writer != null)
            {
                writer.Close();
                writer.Dispose();
                writer = null;
            }
        }

        #endregion
    }
}
