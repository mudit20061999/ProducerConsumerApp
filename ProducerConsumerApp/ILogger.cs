using System;

namespace ProducerConsumerApp
{
    public interface ILogger
    {
        void LogSuccess(string message);
        void LogError(string message, Exception ex);
    }

    public class Logger : ILogger
    {
        private int _successCount;
        private int _errorCount;

        public void LogSuccess(string message)
        {
            _successCount++;
            Console.WriteLine($"Message processed successfully: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            _errorCount++;
            Console.WriteLine($"Error processing message: {message} - {ex.Message}");
        }

        public void PrintStatistics()
        {
            Console.WriteLine($"Total messages processed: {_successCount + _errorCount}");
            Console.WriteLine($"Successful messages: {_successCount}");
            Console.WriteLine($"Error messages: {_errorCount}");
        }
    }
}