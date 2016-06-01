using System;
using System.Diagnostics;

namespace Logger.Strategy
{
    public class WindowsEventLogger : ILog, IDisposable
    {
        private string source = "AddressApp";
        private string log = "Application";

        public void Debug(string debugMessage)
        {
            string mess = "DEBUG: " + debugMessage + DateTime.Now;

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, mess,
                EventLogEntryType.Information, 100);
        }
        public void Error(string errorMessage)
        {
            string mess = "ERROR: " + errorMessage + DateTime.Now;

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, mess,
                EventLogEntryType.Error, 100);
        }

        public void Info(string infoMessage)
        {
            string mess = "INFO: " + infoMessage + DateTime.Now;

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, mess,
                EventLogEntryType.Information, 100);
        }

        public void Warning(string warningMessage)
        {
            string mess = "WARNING: " + warningMessage + DateTime.Now;

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, mess,
                EventLogEntryType.Warning, 100);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
