using DataAccessLayer.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.ModelConfigurations;

public class PublisherAccountConfiguration : IEntityTypeConfiguration<BasePublisherAccount>
{
    public void Configure(EntityTypeBuilder<BasePublisherAccount> builder)
    {
        builder.HasDiscriminator<string>("publisher_account_type")
            .HasValue<PublisherAccount>("publisher_account");

        builder.HasMany(x => x.Subscribers);
    }
}