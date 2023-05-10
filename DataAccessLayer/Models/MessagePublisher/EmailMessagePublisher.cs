using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.MessagePublisher;

public class EmailMessagePublisher : BaseMessagePublisher
{
    public EmailMessagePublisher(string email, Guid id)
    {
        Email = email;
        Id = id;
        Accounts = new List<BasePublisherAccount>();
    }

    protected EmailMessagePublisher() { }
    public string Email { get; set; }
    public override Guid Id { get; set; }
}