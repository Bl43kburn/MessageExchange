using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.MessagePublisher;

namespace BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;

public static class EmailMessagePublisherMapper
{
    public static EmailMessagePublisherDTO AsDto(this EmailMessagePublisher publisher)
        => new EmailMessagePublisherDTO(publisher.Email, publisher.Id, publisher.Accounts.Select(x => x.AsDto()).ToList());
}