using System;
using Utility.Reactive;

namespace Utility.Messaging
{
    internal class MessagingClient : DisposablesHandler, IMessagingClient
    {
        private readonly IObserver<IMessage> _outgoingMessages;

        public MessagingClient(IObservable<IMessage> incomingMessages, IObserver<IMessage> outgoingMessages)
        {
            Messages = incomingMessages;
            _outgoingMessages = outgoingMessages;
        }

        public IObservable<IMessage> Messages { get; private set; }

        public void Send(IMessage message)
        {
            _outgoingMessages.OnNext(message);
        }
    }
}
