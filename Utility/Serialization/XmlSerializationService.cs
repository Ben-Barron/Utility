using System;
using System.IO;
using System.Runtime.Caching;
using System.Xml.Serialization;

namespace Utility.Serialization
{
    public class XmlSerializationService : ISerializationService
    {
        private static CacheItemPolicy ExpirationPolicy = new CacheItemPolicy()
        {
            SlidingExpiration = TimeSpan.FromHours(6.0)
        };

        public T Deserialize<T>(string xml) where T : class
        {
            return Deserialize<T>(xml, typeof(T));
        }

        public T Deserialize<T>(string xml, Type type)
        {
            var serializer = GetSerializer(type);

            using (var reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public T DeserializeFromFile<T>(string filepath) where T : class
        {
            return DeserializeFromFile<T>(filepath, typeof(T));
        }

        public T DeserializeFromFile<T>(string filepath, Type type)
        {
            return Deserialize<T>(File.ReadAllText(filepath), type);
        }

        public string Serialize(object instance)
        {
            var serializer = GetSerializer(instance.GetType());

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, instance);
                return writer.ToString();
            }
        }

        public void SerializeToFile(object instance, string filepath)
        {
            using (var writer = File.CreateText(filepath))
            {
                writer.Write(Serialize(instance));
            }
        }

        private static XmlSerializer GetSerializer(Type type)
        {
            var key = type.FullName;
            var serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(type));

            serializer = MemoryCache.Default.AddOrGetExisting(key, serializer, ExpirationPolicy) as Lazy<XmlSerializer>;

            return serializer.Value;
        }
    }
}
