using System.IO;
using System.Xml.Serialization;

namespace MessageAppDemo.Backend.SystemData.DeepCloner
{
    public static class DeepCloner
    {
        public static T DeepClone<T>(T input)
        {
            
            using var stream = new MemoryStream();

            var serializer = new XmlSerializer(input.GetType());
            serializer.Serialize(stream, input);
            stream.Position = 0;
            return (T)serializer.Deserialize(stream);

        }
    }
}
