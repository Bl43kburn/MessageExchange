using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

public record BasePublisherAccountDTO(IReadOnlyCollection<BaseEmployeeAccountDTO> subscribers, Guid id, string login, string password);