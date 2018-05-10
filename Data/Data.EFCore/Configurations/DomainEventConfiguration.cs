using Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Configurations
{
    public class DomainEventConfiguration : IEntityTypeConfiguration<DomainEventEntity>
    {
        public void Configure(EntityTypeBuilder<DomainEventEntity> builder)
        {
            builder.HasKey(x => new { x.AggregateType, x.SequenceNumber });
            builder.Property(x => x.AggregateType).IsRequired();
            builder.Property(x => x.SequenceNumber).IsRequired();
            builder.Property(x => x.EventType).IsRequired();
            builder.Property(x => x.TimeStamp).IsRequired();

            builder.ToTable("DomainEvent");
        }
    }
}
