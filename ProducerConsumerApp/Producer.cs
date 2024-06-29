using System;

namespace ProducerConsumerApp
{
    public class Producer
    {
        private readonly MessageQueue _messageQueue;

        public Producer(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public void ProduceMessage(string message)
        {
            _messageQueue.Enqueue(message);
            Console.WriteLine($"Produced message: {message}");
        }
    }
}