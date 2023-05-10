using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;

namespace BusinessLogicLayer.Anemic.DTO;

public record ReportDTO(int processedMessages, int timedMessages, BaseEmployeeDTO author, Guid id, DateTime creationDate, IReadOnlyCollection<DeviceCountPairDTO> pairs);