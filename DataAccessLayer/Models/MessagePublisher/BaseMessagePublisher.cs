using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.MessagePublisher;

public abstract class BaseMessagePublisher
{
    public BaseMessagePublisher()
    {
        Accounts = new List<BasePublisherAccount>();
    }

    public virtual ICollection<BasePublisherAccount> Accounts { get; set; }
    public abstract Guid Id { get; set; }

    public override string ToString()
    {
        return $"{Id}";
    }
}