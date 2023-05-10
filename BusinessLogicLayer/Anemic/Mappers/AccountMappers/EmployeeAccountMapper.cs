using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.Mappers.MessagesMappers;
using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.Mappers.AccountMappers;

public static class EmployeeAccountMapper
{
    public static EmployeeAccountDTO AsDto(this EmployeeAccount account)
        => new EmployeeAccountDTO(account.Id, account.Login, account.Password, account.Messages.Select(x => x.AsDto()).ToList());
}