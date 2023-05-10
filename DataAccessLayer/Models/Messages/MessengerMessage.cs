using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models.Messages;

public class MessengerMessage : Message
{
    public MessengerMessage(string title, string body, DateTime creationTime, MessengerMessagePublisher publisher, Guid id, BasePublisherAccount account, string state, string userId)
    {
        (Title, Body, CreationTime, Publisher, Account) = (title, body, creationTime, publisher, account);
        State = state;
        UserId = userId;
        Id = id;
    }

    protected MessengerMessage() { }

    public override string Title { get; set; }
    public override string Body { get; set; }
    public override DateTime CreationTime { get; set; }
    public override string State { get; set; }
    public override BaseMessagePublisher Publisher { get; set; }
    public override Guid Id { get; set; }

    public string UserId { get; set; }
    public override BasePublisherAccount Account { get; set; }
}