using Logger;

namespace AddressBooks_Logger
{
    public class Loggers
    {
        private ILog Ilog;

        public Loggers(ILog _log)
        {
            Ilog = _log;
        }
        public void Info(string infoMessage)
        {
            Ilog.Info(infoMessage);
        }
        public void Debug(string debugMessage)
        {
            Ilog.Debug(debugMessage);
        }
        public void Warning(string warningMessage)
        {
            Ilog.Warning(warningMessage);
        }
        public void Error(string errorMessage)
        {
            Ilog.Error(errorMessage);
        }
    }
}
