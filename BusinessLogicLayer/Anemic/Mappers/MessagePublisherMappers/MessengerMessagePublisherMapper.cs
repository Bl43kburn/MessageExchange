using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.MessagePublisher;

namespace BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;

public static class MessengerMessagePublisherMapper
{
    public static MessengerMessagePublisherDTO AsDto(this MessengerMessagePublisher publisher)
        => new MessengerMessagePublisherDTO(publisher.Accounts.Select(x => x.AsDto()).ToList(), publisher.Id, publisher.UserId);
}