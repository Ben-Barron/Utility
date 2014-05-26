using System;

namespace Utility.Serialization
{
    public interface ISerializationService
    {
        T Deserialize<T>(string xml) where T : class;
        T Deserialize<T>(string xml, Type type);
        T DeserializeFromFile<T>(string filepath) where T : class;
        T DeserializeFromFile<T>(string filepath, Type type);

        string Serialize(object instance);
        void SerializeToFile(object instance, string filepath);
    }
}
