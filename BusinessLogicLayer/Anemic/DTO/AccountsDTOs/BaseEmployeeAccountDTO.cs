using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using DataAccessLayer.Models.Messages;

namespace BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

public record BaseEmployeeAccountDTO(Guid id, string login, string password);