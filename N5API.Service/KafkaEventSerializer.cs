using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

namespace N5API.Service
{
    public class KafkaEventSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
