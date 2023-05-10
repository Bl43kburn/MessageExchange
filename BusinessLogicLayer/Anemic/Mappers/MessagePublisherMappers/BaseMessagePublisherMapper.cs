using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.MessagePublisher;

namespace BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;

public static class BaseMessagePublisherMapper
{
    public static BaseMessagePublisherDTO AsDto(this BaseMessagePublisher publisher)
        => new BaseMessagePublisherDTO(publisher.Accounts.Select(x => x.AsDto()).ToList(), publisher.Id);
}