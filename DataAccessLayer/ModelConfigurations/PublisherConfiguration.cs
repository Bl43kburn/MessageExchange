using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.ModelConfigurations;

public class PublisherConfiguration : IEntityTypeConfiguration<BaseMessagePublisher>
{
    public void Configure(EntityTypeBuilder<BaseMessagePublisher> builder)
    {
        builder.HasDiscriminator<string>("publisher_type")
            .HasValue<EmailMessagePublisher>("email_publisher")
            .HasValue<MessengerMessagePublisher>("messenger_publisher")
            .HasValue<PhoneMessagePublisher>("phone_publisher");
    }
}