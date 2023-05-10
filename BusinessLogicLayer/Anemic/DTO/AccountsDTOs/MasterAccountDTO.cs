using DataAccessLayer.Models;

namespace BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

public record MasterAccountDTO(Guid id, string login, string password, IEnumerable<ReportDTO> reports) : BaseEmployeeAccountDTO(id, login, password);