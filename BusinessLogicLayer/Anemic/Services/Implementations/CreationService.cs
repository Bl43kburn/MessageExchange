using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Exceptions;
using BusinessLogicLayer.Anemic.Mappers;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;
using BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;
using BusinessLogicLayer.Anemic.Mappers.MessagesMappers;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.MessagePublisher;
using DataAccessLayer.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Anemic.Services.Implementations;

public class CreationService : ICreationService
{
    private DatabaseContext _context;

    public CreationService(DatabaseContext context)
    {
        _context = context;
    }

    public PublisherAccountDTO CreatePublisherAccount(string login, string password)
    {
        var account = new PublisherAccount(login, password, Guid.NewGuid());

        var duplicate = _context.PublisherAccounts.FirstOrDefault(x => x.Login.Equals(login));

        if (duplicate is not null)
            throw CreationException.DuplicateAccount();

        _context.PublisherAccounts.Add(account);
        _context.SaveChanges();

        return account.AsDto();
    }

    public EmployeeDTO CreateEmployee(string fullName, int age, string accountLogin, string accountPassword)
    {
        var account = new EmployeeAccount(accountLogin, accountPassword, Guid.NewGuid());
        var employee = new Employee(fullName, age, account, Guid.NewGuid(), account.Id);
        
        var duplicate = _context.EmployeeAccounts.FirstOrDefault(x => x.Login.Equals(accountLogin));

        if (duplicate is not null)
            throw CreationException.DuplicateAccount();
            
        _context.EmployeeAccounts.Add(account);
        _context.Employees.Add(employee);
        _context.SaveChanges();

        return employee.AsDto();
    }

    public MasterDTO CreateMaster(string fullName, int age, string accountLogin, string accountPassword)
    {
        var account = new MasterAccount(accountLogin, accountPassword, Guid.NewGuid());
        var master = new Master(fullName, age, account, Guid.NewGuid(), account.Id);
        
        var duplicate = _context.EmployeeAccounts.OfType<MasterAccount>().FirstOrDefault(x => x.Login.Equals(accountLogin));

        if (duplicate is not null)
            throw CreationException.DuplicateAccount();
            
        _context.EmployeeAccounts.Add(account);
        _context.Employees.Add(master);
        _context.SaveChanges();

        return master.AsDto();
    }

    public EmailMessagePublisherDTO CreateEmailPublisher(string email)
    {
        var publisher = new EmailMessagePublisher(email, new Guid());
        _context.Add(publisher);
        _context.SaveChanges();
        
        return publisher.AsDto();
    }

    public MessengerMessagePublisherDTO CreateMessagePublisher(string userId)
    {
        var publisher = new MessengerMessagePublisher(userId, Guid.NewGuid());
        _context.Add(publisher);
        _context.SaveChanges();
        
        return publisher.AsDto();
    }

    public PhoneMessagePublisherDTO CreatePhonePublisher(string phoneNumber)
    {
        var publisher = new PhoneMessagePublisher(phoneNumber, new Guid());
        _context.Add(publisher);
        _context.SaveChanges();

        return publisher.AsDto();
    }

    public EmailMessageDTO CreateEmailMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate)
    {
        BasePublisherAccount acc = _context.PublisherAccounts.FirstOrDefault(x => x.Id.Equals(account)) ?? throw SearchException<BasePublisherAccount>.NotFound();
        EmailMessagePublisher publis = _context.MessagePublishers.OfType<EmailMessagePublisher>().Include(y => y.Accounts)
            .FirstOrDefault(x => x.Id.Equals(publisher)) ?? throw SearchException<EmailMessagePublisher>.NotFound();


        var message = new EmailMessage(title, body, creationDate, publis, Guid.NewGuid(), acc, "New", publis.Email);
        _context.Add(message);
        _context.SaveChanges();
        
        return message.AsDto();
    }

    public MessengerMessageDTO CreateMessengerMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate)
    {
        BasePublisherAccount acc = _context.PublisherAccounts.FirstOrDefault(x => x.Id.Equals(account)) ?? throw SearchException<BasePublisherAccount>.NotFound();
        MessengerMessagePublisher publis = _context.MessagePublishers.OfType<MessengerMessagePublisher>().Include(y => y.Accounts)
            .FirstOrDefault(x => x.Id.Equals(publisher)) ?? throw SearchException<MessengerMessagePublisher>.NotFound();
        
        var message = new MessengerMessage(title, body, creationDate, publis, Guid.NewGuid(), acc, "New", publis.UserId);
        _context.Add(message);
        _context.SaveChanges();
        
        return message.AsDto();
    }

    public PhoneMessageDTO CreateSmsMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate)
    {
        BasePublisherAccount acc = _context.PublisherAccounts.FirstOrDefault(x => x.Id.Equals(account)) ?? throw SearchException<BasePublisherAccount>.NotFound();
        PhoneMessagePublisher publis = _context.MessagePublishers.OfType<PhoneMessagePublisher>().Include(y => y.Accounts)
            .FirstOrDefault(x => x.Id.Equals(publisher)) ?? throw SearchException<PhoneMessagePublisher>.NotFound();

        var message = new SmsMessage(title, body, creationDate, publis, Guid.NewGuid(), acc, "New", publis.PhoneNumber);
        _context.Add(message);
        _context.SaveChanges();

        return message.AsDto();
    }

    public ReportDTO CreateReport(Guid sessionId, DateTime durationStart, DateTime durationEnd, DateTime creationDate)
    {
        var session = _context.Sessions.FirstOrDefault(x => x.Id.Equals(sessionId)) ?? throw SessionException.SessionNotActive(sessionId);
        
        Master mas = _context.Employees.OfType<Master>().Include(a => a.Subordinates).FirstOrDefault(x => x.Id.Equals(session.EmployeeId)) ?? throw SearchException<Master>.NotFound();
        var subordinateAccountId = mas.Subordinates.Select(x => x.AccountId);
        
        var subordinates = _context.
            EmployeeAccounts.OfType<EmployeeAccount>().
            Include(m => m.Messages).ThenInclude(a => a.Publisher).
            Include(z => z.Messages).ThenInclude(v => v.Account).
            Select(y => y).
            Where(x => subordinateAccountId.Contains(x.Id)).
            ToList();
        
        int processedMessages = subordinates.SelectMany(x => x.Messages).Count(x => x.State.Equals("Processed"));
        
        var deviceCountPairs = AggregateDeviceMessageCount(subordinates).ToList();

        int timedMessages = subordinates.SelectMany(x =>
            x.Messages.Select(y => y).Where(y =>
                y.CreationTime >= durationStart && y.CreationTime <= durationEnd)).Count();

        var report = new Report(processedMessages, timedMessages, mas, Guid.NewGuid(), creationDate);

        report.DeviceCountPairs = deviceCountPairs;

        _context.Add(report);
        _context.DeviceInfo.AddRange(deviceCountPairs);
        _context.SaveChanges();

        return report.AsDto();
    }

    private IEnumerable<DeviceCountPair> AggregateDeviceMessageCount(IEnumerable<EmployeeAccount> accounts)
    {
        var pairs = new Dictionary<BaseMessagePublisher, int>();
        IEnumerable<Message> messages = accounts.SelectMany(x => x.Messages);
        foreach (Message x in messages)
        {
            if (pairs.ContainsKey(x.Publisher))
                pairs[x.Publisher] += 1;
            else
                pairs.Add(x.Publisher, 1);
        }

        return pairs.Select(x => new DeviceCountPair(x.Key, x.Value, new Guid())).ToList().AsReadOnly();
    }
}