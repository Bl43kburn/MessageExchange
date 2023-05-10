using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;

public record BaseEmployeeDTO(string fullName, int age, Guid id, Guid accountId);