using BusinessLogicLayer.Anemic.Exceptions;
using DataAccessLayer;
using DataAccessLayer.Models.Messages;
using MediatR;

namespace BusinessLogicLayer.Anemic.Requests.Handlers;

public class MarkProcessedCommand : IRequestHandler<MarkProcessed>
{
    private DatabaseContext _context;

    public MarkProcessedCommand(DatabaseContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(MarkProcessed request, CancellationToken cancellationToken)
    {
        var session = _context.Sessions.FirstOrDefault(x => x.Id.Equals(request.sessionId)) ?? throw SessionException.SessionNotActive(request.sessionId);
        var message = _context.Messages.SingleOrDefault(x => x.Id.Equals(request.messageId)) ?? throw SearchException<Message>.NotFound();

        message.State = "Processed";
        _context.Messages.Update(message);

        _context.SaveChanges();
        return Task.FromResult(Unit.Value);
    }
}