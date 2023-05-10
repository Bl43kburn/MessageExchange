using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.Mappers.AccountMappers;

public static class PublisherAccountMapper
{
    public static PublisherAccountDTO AsDto(this PublisherAccount account)
        => new PublisherAccountDTO(account.Subscribers.Select(x => x.AsDto()).ToList(), account.Id, account.Login, account.Password);
}