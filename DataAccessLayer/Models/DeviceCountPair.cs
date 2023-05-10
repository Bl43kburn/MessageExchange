using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models;

public class DeviceCountPair
{
    public DeviceCountPair(BaseMessagePublisher publisher, int messages, Guid id)
    {
        Publisher = publisher;
        Messages = messages;
        Id = id;
    }

    protected DeviceCountPair() { }
    public BaseMessagePublisher Publisher { get; set; }
    public int Messages { get; set; }
    public Guid Id { get; set; }
}