using System;

namespace ProducerConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageQueue = new MessageQueue();
            var logger = new Logger();
            var producer = new Producer(messageQueue);
            var consumer = new Consumer(messageQueue, logger);

            // Produce 10 messages
            for (int i = 0; i < 10; i++)
            {
                producer.ProduceMessage($"Message {i}");
            }

            // Consume messages
            for (int i = 0; i < 10; i++)
            {
                consumer.ConsumeMessage();
            }

            logger.PrintStatistics();
        }
    }
}