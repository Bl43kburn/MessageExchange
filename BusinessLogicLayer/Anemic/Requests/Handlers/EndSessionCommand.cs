using BusinessLogicLayer.Anemic.Exceptions;
using DataAccessLayer;
using MediatR;

namespace BusinessLogicLayer.Anemic.Requests.Handlers;

public class EndSessionCommand : IRequestHandler<EndSession>
{
    private DatabaseContext _context;

    public EndSessionCommand(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<Unit> Handle(EndSession request, CancellationToken cancellationToken)
    {
       var session = _context.Sessions.FirstOrDefault(x => x.Id.Equals(request.sessionId)) ?? throw SessionException.SessionNotActive(request.sessionId);
       _context.Sessions.Remove(session);
       _context.SaveChanges();
       return Task<Unit>.FromResult(Unit.Value);
    }
}