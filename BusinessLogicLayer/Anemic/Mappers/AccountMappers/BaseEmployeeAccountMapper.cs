using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.Mappers.MessagesMappers;
using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.Mappers.AccountMappers;

public static class BaseEmployeeAccountMapper
{
    public static BaseEmployeeAccountDTO AsDto(this BaseEmployeeAccount account)
        => new BaseEmployeeAccountDTO(account.Id, account.Login, account.Password);
}