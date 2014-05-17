using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml.Serialization;

namespace Utility.Extensions
{
    public static class SerializerExtensions
    {
        // TODO: this should be changed to a MemoryCache where the items expire
        private static ConcurrentDictionary<Type, XmlSerializer> _serializers = new ConcurrentDictionary<Type, XmlSerializer>();

        public static T Deserialize<T>(this string xml) where T : class
        {
            return Deserialize<T>(xml, typeof(T));
        }

        public static T Deserialize<T>(this string xml, Type type)
        {
            var serializer = GetSerializer(type);

            using (var reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static T DeserializeFromFile<T>(this string filepath) where T : class
        {
            return DeserializeFromFile<T>(filepath, typeof(T));
        }

        public static T DeserializeFromFile<T>(this string filepath, Type type)
        {
            return Deserialize<T>(File.ReadAllText(filepath), type);
        }

        public static string Serialize(this object obj)
        {
            var serializer = GetSerializer(obj.GetType());

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static void SerializeToFile(this object instance, string filepath)
        {
            using (var writer = File.CreateText(filepath))
            {
                writer.Write(Serialize(instance));
            }
        }

        private static XmlSerializer GetSerializer(Type type)
        {
            return _serializers.GetOrAdd(type, key => new XmlSerializer(key));
        }
    }
}
