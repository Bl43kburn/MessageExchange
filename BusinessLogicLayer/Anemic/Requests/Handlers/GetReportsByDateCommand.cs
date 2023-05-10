using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.Exceptions;
using BusinessLogicLayer.Anemic.Mappers;
using BusinessLogicLayer.Anemic.Services.Implementations;
using DataAccessLayer;
using DataAccessLayer.Models.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Anemic.Requests.Handlers;

public class GetReportsByDateCommand : IRequestHandler<GetReportsByDate, IEnumerable<ReportDTO>>
{
    private DatabaseContext _context;

    public GetReportsByDateCommand(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<ReportDTO>> Handle(GetReportsByDate request, CancellationToken cancellationToken)
    {
        var session = _context.Sessions.FirstOrDefault(x => x.Id.Equals(request.sessionId)) ?? throw SessionException.SessionNotActive(request.sessionId);

        var reports = _context.Reports.Include(x => x.DeviceCountPairs)
            .ThenInclude(f => f.Publisher)
            .Include(a => a.Author)
            .Where(x => x.Author.Id.Equals(session.EmployeeId))
            .Where(x => x.CreationDate >= request.startingDate);
        return Task.FromResult(reports.Select(x => x.AsDto()).AsEnumerable());
    }
}