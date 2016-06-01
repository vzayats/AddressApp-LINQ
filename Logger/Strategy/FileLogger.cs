using System;
using System.IO;

namespace Logger.Strategy
{
    public class FileLogger : ILog
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt";
        private object sw;

        public void Debug(string debugMessage)
        {
            FileOutput("DEBUG: " + debugMessage + DateTime.Now);
        }

        public void Error(string errorMessage)
        {
            FileOutput("ERROR: " + errorMessage + DateTime.Now);
        }

        public void Info(string infoMessage)
        {
            FileOutput("INFO: " + infoMessage + DateTime.Now);
        }

        public void Warning(string warningMessage)
        {
            FileOutput("WARNING: " + warningMessage + DateTime.Now);
        }
        //Save to .txt file in bin\Debug folder
        private void FileOutput(string mess)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(mess);
                    sw.Dispose();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
