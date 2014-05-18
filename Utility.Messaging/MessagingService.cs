using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Utility.Extensions;
using Utility.Logging;
using Utility.Reactive;
using Utility.Reactive.Extensions;

namespace Utility.Messaging
{
    public class MessagingService : DisposablesHandler, IMessagingService
    {
        private readonly ConcurrentDictionary<Type, IMessagingClient> _clients;
        private readonly Subject<IObservable<IMessage>> _clientMessageStreams;
        private readonly IObservable<IMessage> _allClientMessages;
        private readonly ILogger _logger;

        public MessagingService(ILogFactory logFactory)
        {
            _clients = new ConcurrentDictionary<Type, IMessagingClient>();
            _clientMessageStreams = new Subject<IObservable<IMessage>>();
            _allClientMessages = _clientMessageStreams.Merge();
            _logger = logFactory.GetLogger<MessagingService>();

            _clientMessageStreams.DisposeWith(this);
        }

        public IMessagingClient Register<T>()
        {
            return Register(typeof(T));
        }

        public IMessagingClient Register(Type type)
        {
            var addresses = new List<string>() { type.FullName };
            var attribute = type.GetAttribute<MessageClientAddress>();

            if (attribute != null)
            {
                addresses.AddRange(attribute.Addresses);
            }

            return _clients.GetOrAdd(type,
                (key) =>
                {
                    _logger.Debug("Message client does not exist for '{0}', creating one.", key.FullName);

                    var incomingMessages = _allClientMessages.Where(m => m.Addresses.Any(addresses.Contains));
                    var outgoingMessages = new Subject<IMessage>();
                    var client = new MessagingClient(incomingMessages, outgoingMessages);

                    _clientMessageStreams.OnNext(outgoingMessages);

                    Disposable.Create(
                        () =>
                        {
                            _clients.TryRemove(key);
                            outgoingMessages.OnCompleted();
                            outgoingMessages.Dispose();
                        })
                        .DisposeWith(client);

                    return client;
                });
        }
    }
}
