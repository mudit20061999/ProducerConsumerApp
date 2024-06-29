using Xunit;
using Moq;
using ProducerConsumerApp;

namespace ProducerConsumerAppTests
{
    public class ProducerTests
    {
        [Fact]
        public void ProduceMessage_AddsMessageToQueue()
        {
            var messageQueueMock = new Mock<MessageQueue>();
            var producer = new Producer(messageQueueMock.Object);

            producer.ProduceMessage("Test message");

            messageQueueMock.Verify(m => m.Enqueue("Test message"), Times.Once);
        }
    }
}