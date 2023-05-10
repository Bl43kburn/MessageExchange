using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.MessagePublisher;

public class MessengerMessagePublisher : BaseMessagePublisher
{
    public MessengerMessagePublisher(string userId, Guid id)
    {
        UserId = userId;
        Id = id;
        Accounts = new List<BasePublisherAccount>();
    }

    protected MessengerMessagePublisher() { }
    public string UserId { get; set; }
    public override Guid Id { get; set; }
}