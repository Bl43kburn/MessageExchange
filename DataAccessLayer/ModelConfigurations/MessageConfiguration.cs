using DataAccessLayer.Models.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.ModelConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasDiscriminator<string>("message_type")
            .HasValue<EmailMessage>("email_message")
            .HasValue<SmsMessage>("sms_message")
            .HasValue<MessengerMessage>("messenger_message");
    }
}