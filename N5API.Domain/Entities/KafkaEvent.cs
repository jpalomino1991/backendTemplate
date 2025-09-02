namespace N5API.Domain.Entities
{
    public class KafkaEvent
    {
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }
    }
}
