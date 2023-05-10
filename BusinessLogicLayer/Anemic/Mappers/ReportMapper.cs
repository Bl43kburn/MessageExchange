using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Anemic.Mappers;

public static class ReportMapper
{
    public static ReportDTO AsDto(this Report report)
        => new ReportDTO(report.ProcessedMessages, report.TimedMessages, report.Author.AsDto(), report.Id, report.CreationDate, report.DeviceCountPairs.Select(x => x.AsDto()).ToList());
}