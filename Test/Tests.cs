using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Exceptions;
using BusinessLogicLayer.Anemic.Mappers.MessagesMappers;
using BusinessLogicLayer.Anemic.Requests;
using BusinessLogicLayer.Anemic.Services;
using BusinessLogicLayer.Anemic.Services.Implementations;
using DataAccessLayer;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.MessagePublisher;
using DataAccessLayer.Models.Messages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.DependencyInjection;

namespace Lab6.Test;

[Startup(typeof(Startup))]
public class Tests
{
    private DatabaseContext _context;
    private ICreationService _creationService;
    private IAssignmentService _assignmentService;
    private EmployeeDTO _employee;
    private MasterDTO _master;
    private MessengerMessagePublisherDTO _publisher;
    private PublisherAccountDTO _publisherAccount;
    private BaseMessageDTO _message;
    private IMediator _mediator;
    private Guid _masterSessionId;
    private Guid _employeeSessionId;

    public Tests(DatabaseContext context, IMediator mediator)
    {
        _context = context;
        _creationService = new CreationService(_context);
        _assignmentService = new AssignmentService(_context);
        _mediator = mediator;
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        EntityCreation_Binding_Authentication();
    }

    [Fact]
    public void B_EnsureBinding()
    {
        var publisher = _context.MessagePublishers.OfType<MessengerMessagePublisher>().Include(a => a.Accounts)
            .FirstOrDefault(x => x.Id.Equals(_publisher.id)) ?? throw SearchException<MessengerMessagePublisher>.NotFound();

        var master = _context.Employees.OfType<Master>().Include(a => a.Subordinates)
            .FirstOrDefault(x => x.Id.Equals(_master.id)) ?? throw SearchException<Master>.NotFound();

        var publisherAccount = _context.PublisherAccounts.Include(a => a.Subscribers)
                                   .FirstOrDefault(x => x.Id.Equals(_publisherAccount.id)) ?? throw SearchException<BasePublisherAccount>.NotFound();

        Assert.Contains(_employee.id, master.Subordinates.Select(x => x.Id));
        Assert.Contains(_publisherAccount.id, publisher.Accounts.Select(x => x.Id));
        Assert.Contains(_employee.accountId, publisherAccount.Subscribers.Select(x => x.Id));
    }

    [Fact]
    public void A_Authentication_Check()
    {
        var sessionModelEmp = _context.Sessions.FirstOrDefault(x => x.Id.Equals(_employeeSessionId)) ??
                              throw SessionException.SessionNotActive(_employeeSessionId);
        var sessionModelMas = _context.Sessions.FirstOrDefault(x => x.Id.Equals(_masterSessionId)) ??
                              throw SessionException.SessionNotActive(_masterSessionId);
    }

    [Fact]
    public void C_MessageAggregation()
    {
        var aggr = new AggregateMessages(_employeeSessionId);
        var result = _mediator.Send(aggr).Result.ToList();

        _message = result[0];
        Assert.Contains(_message.id, result.Select(x => x.id));
        Assert.Equal("Received", result[0].state);
    }

    [Fact]
    public void D_MessageProcessed()
    {
        var markProcessed = new MarkProcessed(_employeeSessionId, _message.id);
        _mediator.Send(markProcessed);

        var baseMessage = _context.Messages.Include(x => x.Publisher).Include(y => y.Account)
            .FirstOrDefault(z => z.Id.Equals(_message.id)) ?? throw SearchException<Message>.NotFound();
        _message = baseMessage.AsDto();

        Assert.Equal("Processed", baseMessage.State);
    }

    [Fact]
    public void E_ReportCreation_Lookup()
    {
        DateTime durationStart = new DateTime(2022, 12, 10);
        DateTime creationDate = new DateTime(2022, 12, 15);
        var report = _creationService.CreateReport(_masterSessionId, durationStart, DateTime.Now, creationDate);

        var request = new GetReportsByDate(durationStart, _masterSessionId);
        var result = _mediator.Send(request).Result.ToList()[0];
        Assert.Equal(report.id, result.id);
    }

    private void EntityCreation_Binding_Authentication()
    {
        _employee = _creationService.CreateEmployee("Sergei", 22, "zaza", "zaza");
        _master = _creationService.CreateMaster("Vladislav", 32, "fada", "akum");
        _publisher = _creationService.CreateMessagePublisher("vanya2003");
        _publisherAccount = _creationService.CreatePublisherAccount("Vasya2002", "wawa");
        _assignmentService.AssignAccountToPublisher(_publisher.id, _publisherAccount.id);
        _message = _creationService.CreateMessengerMessage(_publisherAccount.id, _publisher.id, "Hi", "Privet", DateTime.Today.Subtract(new TimeSpan(1, 0, 0)));

        _assignmentService.AssignSubordinate(_master.id, _employee.id);
        _assignmentService.AssignEmployeeAccountToPublisher(_publisherAccount.id, _employee.accountId);

        var empAuth = new Authorize("zaza", "zaza");
        var masAuth = new Authorize("fada", "akum");

        var responseEmp = _mediator.Send(empAuth);
        var responseMas = _mediator.Send(masAuth);

        _employeeSessionId = responseEmp.Result;
        _masterSessionId = responseMas.Result;
    }
}