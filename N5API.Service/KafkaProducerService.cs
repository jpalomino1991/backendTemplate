using Confluent.Kafka;
using Microsoft.Extensions.Options;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.Entities;

namespace N5API.Service
{
    public class KafkaProducerService : IProducerService
    {
        private readonly KafkaConfig _kafkaConfig;
        private readonly ISerializer<KafkaEvent> _serializer;

        public KafkaProducerService(IOptions<KafkaConfig> kafkaConfig, ISerializer<KafkaEvent> serializer)
        {
            _kafkaConfig = kafkaConfig.Value;
            _serializer = serializer;
        }

        public Task ProduceMessage(KafkaEvent kafkaEvent)
        {
            var config = new ProducerConfig { BootstrapServers = _kafkaConfig.BootstrapServers };

            using (var producer = new ProducerBuilder<Null, KafkaEvent>(config)
            .SetValueSerializer(_serializer)
            .Build())
            {
                //producer.Produce(, new Message<Null, KafkaEvent> { Value = kafkaEvent });
                producer.Produce(_kafkaConfig.Topic, new Message<Null, KafkaEvent> { Value = kafkaEvent },
                        (deliveryReport) =>
                        {
                            if (deliveryReport.Error.Code != ErrorCode.NoError)
                            {
                                Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                            }
                            else
                            {
                                Console.WriteLine($"Produced message to: {deliveryReport.TopicPartitionOffset}");
                            }
                        });

                producer.Flush(TimeSpan.FromSeconds(10));
            }

            return Task.CompletedTask;
        }
    }
}
