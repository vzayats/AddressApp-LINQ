namespace Logger
{
    public interface ILog
    {
        void Info(string infoMessage);
        void Debug(string debugMessage);
        void Warning(string warningMessage);
        void Error(string errorMessage);
    }
}
