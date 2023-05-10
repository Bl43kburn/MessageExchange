using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;

public record EmployeeDTO(string fullName, int age, Guid id, Guid accountId) : BaseEmployeeDTO(fullName, age, id, accountId);