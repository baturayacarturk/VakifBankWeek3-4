namespace BOOKSTORE.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("Console Logging... " + message);
        }
    }
}
