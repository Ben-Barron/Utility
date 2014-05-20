using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Utility.Extensions;
using Utility.Logging;
using Utility.Reactive;
using Utility.Reactive.Extensions;
using Utility.Reactive.Subjects;

namespace Utility.Messaging
{
    public class MessagingService : DisposablesHandler, IMessagingService
    {
        private readonly ConcurrentDictionary<Type, IMessagingClient> _clients;
        private readonly IMergedStreamSubjectFactory<IMessage> _mergedStreamSubjectFactory;
        private readonly ILogger _logger;

        public MessagingService(ILogFactory logFactory)
        {
            _clients = new ConcurrentDictionary<Type, IMessagingClient>();
            _mergedStreamSubjectFactory = new MergedStreamSubjectFactory<IMessage>();
            _logger = logFactory.GetLogger<MessagingService>();
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

                    var incomingMessages = _mergedStreamSubjectFactory.MergedStream.Where(m => m.Addresses.Any(addresses.Contains));
                    var outgoingMessages = _mergedStreamSubjectFactory.GetNewSubject();
                    var client = new MessagingClient(incomingMessages, outgoingMessages);

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
