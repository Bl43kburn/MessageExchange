using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models.Messages;

public class SmsMessage : Message
{
    public SmsMessage(string title, string body, DateTime creationTime, PhoneMessagePublisher publisher, Guid id, BasePublisherAccount account, string state, string phoneNumber)
    {
        (Title, Body, CreationTime, Publisher, Account) = (title, body, creationTime, publisher, account);
        State = state;
        PhoneNumber = phoneNumber;
        Id = id;
    }

    protected SmsMessage() { }

    public override BaseMessagePublisher Publisher { get; set; }
    public override string Title { get; set; }
    public override string Body { get; set; }
    public override DateTime CreationTime { get; set; }
    public override string State { get; set; }
    public override Guid Id { get; set; }
    public override BasePublisherAccount Account { get; set; }

    public string PhoneNumber { get; set; }
}