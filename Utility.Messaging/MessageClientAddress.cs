using System;

namespace Utility.Messaging
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MessageClientAddress : Attribute
    {
        public MessageClientAddress(string address)
            : this(new[] { address })
        {
        }

        public MessageClientAddress(string[] addresses)
        {
            Addresses = addresses;
        }

        public string[] Addresses { get; private set; }
    }
}
