
namespace Utility.Messaging
{
    public class Message<T> : IMessage<T>
    {
        public Message(string address, T content)
            : this(new[] { address }, content)
        {
        }

        public Message(string[] addresses, T content)
        {
            Addresses = addresses;
            Content = content;
        }

        public string[] Addresses { get; private set; }
        
        public T Content { get; private set; }
        
        object IMessage.Content { get { return Content; } }
    }
}
