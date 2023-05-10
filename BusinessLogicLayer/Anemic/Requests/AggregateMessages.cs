using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using MediatR;

namespace BusinessLogicLayer.Anemic.Requests;

public class AggregateMessages : IRequest<IEnumerable<BaseMessageDTO>>
{
    public AggregateMessages(Guid id)
    {
        SessionId = id;
    }
    
    public Guid SessionId { get; set; }
}