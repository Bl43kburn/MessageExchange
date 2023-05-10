using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;

public record MasterDTO(string fullName, int age, Guid id, Guid accountId, IEnumerable<BaseEmployeeDTO> subordinates) : BaseEmployeeDTO(fullName, age, id, accountId);
    
