using N5API.Domain.Entities;

namespace N5API.Domain.Abstractions.Service
{
    public interface IProducerService
    {
        Task ProduceMessage(KafkaEvent message);
    }
}
