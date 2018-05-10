using System;

namespace Data.EFCore.Entities
{
    public class DomainEventEntity
    {
        public string AggregateType { get; set; }
        public int SequenceNumber { get; set; }
        public string EventType { get; set; }
        public Guid EntityId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
