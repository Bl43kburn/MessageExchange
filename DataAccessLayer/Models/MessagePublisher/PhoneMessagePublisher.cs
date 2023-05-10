using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.MessagePublisher;

public class PhoneMessagePublisher : BaseMessagePublisher
{
    public PhoneMessagePublisher(string phoneNumber, Guid id)
    {
        PhoneNumber = phoneNumber;
        Id = id;
        Accounts = new List<BasePublisherAccount>();
    }

    protected PhoneMessagePublisher() { }
    public string PhoneNumber { get; set; }
    public override Guid Id { get; set; }
}