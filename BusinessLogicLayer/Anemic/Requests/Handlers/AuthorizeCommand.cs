using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Exceptions;
using BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using MediatR;

namespace BusinessLogicLayer.Anemic.Requests.Handlers;

public class AuthorizeCommand : IRequestHandler<Authorize, Guid>
{
    private DatabaseContext _context;

    public AuthorizeCommand(DatabaseContext context)
    {
        _context = context;
    }

    public Task<Guid> Handle(Authorize request, CancellationToken cancellationToken)
    {

        var account = _context.EmployeeAccounts.FirstOrDefault(x => x.Login.Equals(request.Login) && x.Password.Equals(request.Password)) ?? throw SearchException<BaseEmployeeAccount>.NotFound();
        var owner = _context.Employees.FirstOrDefault(x => x.AccountId.Equals(account.Id)) ?? throw SearchException<BaseEmployee>.NotFound();
        var session = new ActiveSessionModel(owner);
        _context.Sessions.Add(session);
        _context.SaveChanges();

        return Task.FromResult(session.Id);
    }
}