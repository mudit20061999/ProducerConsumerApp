using Xunit;
using Moq;
using ProducerConsumerApp;

namespace ProducerConsumerAppTests
{
    public class ConsumerTests
    {
        [Fact]
        public void ConsumeMessage_ProcessesMessageSuccessfully()
        {
            var messageQueueMock = new Mock<MessageQueue>();
            var loggerMock = new Mock<ILogger>();
            var consumer = new Consumer(messageQueueMock.Object, loggerMock.Object);

            messageQueueMock.Setup(m => m.Dequeue()).Returns("Test message");

            consumer.ConsumeMessage();

            loggerMock.Verify(m => m.LogSuccess("Test message"), Times.Once);
        }

        [Fact]
        public void ConsumeMessage_LogsErrorWhenProcessingFails()
        {
            var messageQueueMock = new Mock<MessageQueue>();
            var loggerMock = new Mock<ILogger>();
            var consumer = new Consumer(messageQueueMock.Object, loggerMock.Object);

            messageQueueMock.Setup(m => m.Dequeue()).Returns("Error message");

            consumer.ConsumeMessage();

            loggerMock.Verify(m => m.LogError("Error message", It.IsAny<Exception>()), Times.Once);
        }
    }
}