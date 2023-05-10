using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using DataAccessLayer.Models.Messages;

namespace BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

public record EmployeeAccountDTO(Guid id, string login, string password, IReadOnlyCollection<BaseMessageDTO> messages) : BaseEmployeeAccountDTO(id, login, password);