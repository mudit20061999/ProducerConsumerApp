using System;

namespace ProducerConsumerApp
{
    public class Consumer
    {
        private readonly MessageQueue _messageQueue;
        private readonly ILogger _logger;

        public Consumer(MessageQueue messageQueue, ILogger logger)
        {
            _messageQueue = messageQueue;
            _logger = logger;
        }

        public void ConsumeMessage()
        {
            var message = _messageQueue.Dequeue();
            if (message == null) return;

            try
            {
                ProcessMessage(message);
                _logger.LogSuccess(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(message, ex);
            }
        }

        private void ProcessMessage(string message)
        {
            // Simulate processing the message
            Console.WriteLine($"Consumed message: {message}");
            // Simulate a 20% chance of failure
            if (new Random().Next(0, 10) < 2) throw new Exception("Message processing failed");
        }
    }
}