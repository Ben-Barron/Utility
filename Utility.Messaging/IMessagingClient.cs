using System;

namespace Utility.Messaging
{
    public interface IMessagingClient
    {
        IObservable<IMessage> Messages { get; }

        void Send(IMessage message);
    }
}
