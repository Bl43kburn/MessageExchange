using DataAccessLayer.Models.Accounts;

namespace BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

public record PublisherAccountDTO(IReadOnlyCollection<BaseEmployeeAccountDTO> subscribers, Guid id, string login, string password) : BasePublisherAccountDTO(subscribers, id, login, password);