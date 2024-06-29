using System.Collections.Generic;

namespace ProducerConsumerApp
{
    public class MessageQueue
    {
        private readonly List<string> _messages = new List<string>();

        public void Enqueue(string message)
        {
            _messages.Add(message);
        }

        public string Dequeue()
        {
            if (_messages.Count == 0) return null;
            var message = _messages[0];
            _messages.RemoveAt(0);
            return message;
        }
    }
}