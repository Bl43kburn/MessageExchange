using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BasePublisherAccount = DataAccessLayer.Models.Accounts.BasePublisherAccount;

namespace BusinessLogicLayer.Anemic.Mappers.AccountMappers;

public static class BasePublisherAccountMapper
{
    public static BasePublisherAccountDTO AsDto(this BasePublisherAccount account)
        => new BasePublisherAccountDTO(account.Subscribers.Select(x => x.AsDto()).ToList(), account.Id, account.Login, account.Password);
}