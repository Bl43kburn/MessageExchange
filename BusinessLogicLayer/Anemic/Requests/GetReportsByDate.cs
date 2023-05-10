using BusinessLogicLayer.Anemic.DTO;
using MediatR;
using DataAccessLayer.Models;
namespace BusinessLogicLayer.Anemic.Requests;

public record GetReportsByDate(DateTime startingDate, Guid sessionId) : IRequest<IEnumerable<ReportDTO>>;
