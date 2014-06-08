
namespace Utility.Messaging
{
    public interface IMessage
    {
        string[] Addresses { get; }
        object Payload { get; }
    }

    public interface IMessage<T> : IMessage
    {
        new T Payload { get; }
    }
}
