using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models.Messages;

public abstract class Message
{
    protected Message() { }
    public abstract string Title { get; set; }
    public abstract string Body { get; set; }
    public abstract DateTime CreationTime { get; set; }
    public abstract BaseMessagePublisher Publisher { get; set; }

    public abstract BasePublisherAccount Account { get; set; }
    public abstract string State { get; set; }
    public abstract Guid Id { get; set; }
}