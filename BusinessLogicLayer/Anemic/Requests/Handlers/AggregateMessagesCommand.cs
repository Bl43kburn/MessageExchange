using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Exceptions;
using BusinessLogicLayer.Anemic.Mappers.MessagesMappers;
using DataAccessLayer;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.Messages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Anemic.Requests.Handlers;

public class AggregateMessagesCommand : IRequestHandler<AggregateMessages, IEnumerable<BaseMessageDTO>>
{
    private DatabaseContext _context;

    public AggregateMessagesCommand(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<BaseMessageDTO>> Handle(AggregateMessages request, CancellationToken cancellationToken)
    {
        var session = _context.Sessions.FirstOrDefault(x => x.Id.Equals(request.SessionId)) ?? throw SessionException.SessionNotActive(request.SessionId);

        var employeeAccount = _context.EmployeeAccounts.OfType<EmployeeAccount>().FirstOrDefault(x => x.Id.Equals(session.EmployeeAccountId)) ?? throw SearchException<EmployeeAccount>.NotFound();

        var accounts = _context.PublisherAccounts.Include(y => y.Subscribers)
            .Select(x => x)
            .Where(y => y.Subscribers.Select(x => x.Id.Equals(session.EmployeeAccountId)).Any())
            .AsEnumerable();

        var accountIds = accounts.Select(x => x.Id).AsEnumerable();

        var messages = _context.Messages
            .Include(a => a.Account)
            .Include(b => b.Publisher)
            .Select(x => x)
            .Where(y => accountIds.Contains(y.Account.Id))
            .AsEnumerable();


        foreach (var message in messages)
        {

            if (message.State == "New")
            {
                message.State = "Received";
                _context.Messages.Update(message);
            }
            employeeAccount.Messages.Add(message);
        }

        _context.EmployeeAccounts.Update(employeeAccount);
        _context.SaveChanges();

        
        return Task.FromResult(messages.Select(x => x.AsDto()));
    }
}