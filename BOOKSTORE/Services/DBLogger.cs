namespace BOOKSTORE.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("DbLogging... " + message);
        }
    }
}
