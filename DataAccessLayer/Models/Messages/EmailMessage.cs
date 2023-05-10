using System.Security;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models.Messages;

public class EmailMessage : Message
{
    public EmailMessage(string title, string body, DateTime creationTime, EmailMessagePublisher publisher, Guid id, BasePublisherAccount account, string state, string email)
    {
        (Title, Body, CreationTime, Publisher, Account) = (title, body, creationTime, publisher, account);
        State = state;
        Email = email;
        Id = id;
    }

    protected EmailMessage() { }

    public override string Title { get; set; }
    public override string Body { get; set; }
    public override BaseMessagePublisher Publisher { get; set; }
    public override DateTime CreationTime { get; set; }

    public override BasePublisherAccount Account { get; set; }
    public override string State { get; set; }
    public override Guid Id { get; set; }

    public string Email { get; set; }
}