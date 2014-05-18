
namespace Utility.Messaging
{
    public interface IMessage
    {
        string[] Addresses { get; }
        object Content { get; }
    }

    public interface IMessage<T> : IMessage
    {
        new T Content { get; }
    }
}
