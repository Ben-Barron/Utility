using System;

namespace Utility.Messaging
{
    public interface IMessagingService
    {
        IMessagingClient Register<T>();
        IMessagingClient Register(Type type);
    }
}
