using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.MessagePublisher;

namespace BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;

public static class PhoneMessagePublisherMapper
{
    public static PhoneMessagePublisherDTO AsDto(this PhoneMessagePublisher publisher)
        => new PhoneMessagePublisherDTO(publisher.Accounts.Select(x => x.AsDto()).ToList(), publisher.Id, publisher.PhoneNumber);
}