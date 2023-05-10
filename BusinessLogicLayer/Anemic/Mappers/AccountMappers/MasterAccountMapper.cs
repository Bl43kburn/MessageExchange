using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.Mappers.AccountMappers;

public static class MasterAccountMapper
{
    public static MasterAccountDTO AsDto(this MasterAccount account)
        => new MasterAccountDTO(account.Id, account.Login, account.Password, account.Reports.Select(x => x.AsDto()));
}