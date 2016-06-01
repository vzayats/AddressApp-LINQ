using System;

namespace Logger.Strategy
{
    public class ConsoleLogger : ILog
    {
        public void Debug(string debugMessage)
        {
            ConsoleOutput("DEBUG: " + debugMessage + DateTime.Now);
        }
        public void Error(string errorMessage)
        {
            ConsoleOutput("ERROR: " + errorMessage + DateTime.Now);
        }

        public void Info(string infoMessage)
        {
            ConsoleOutput("INFO: " + infoMessage + DateTime.Now);
        }

        public void Warning(string warningMessage)
        {
            ConsoleOutput("WARNING: " + warningMessage + DateTime.Now);
        }
        private void ConsoleOutput(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
