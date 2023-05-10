using BusinessLogicLayer.Anemic.Exceptions;
using DataAccessLayer;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.MessagePublisher;
using Microsoft.EntityFrameworkCore;
using BasePublisherAccount = DataAccessLayer.Models.Accounts.BasePublisherAccount;

namespace BusinessLogicLayer.Anemic.Services.Implementations;

public class AssignmentService : IAssignmentService
{
    private DatabaseContext _context;

    public AssignmentService(DatabaseContext context)
    {
        _context = context;
    }


    public void AssignSubordinate(Guid master, Guid subordinate)
    {
        var mas = _context.Employees.OfType<Master>().Include(x => x.Subordinates).FirstOrDefault(x => x.Id.Equals(master)) ?? throw SearchException<Master>.NotFound();
        var sub = _context.Employees.OfType<Employee>().FirstOrDefault(x => x.Id.Equals(subordinate)) ?? throw SearchException<Employee>.NotFound();

        if (mas.Subordinates.Any(x => x.Id.Equals(sub.Id)))
            throw AssignmentException.DuplicateAssignment();
        
        mas.Subordinates.Add(sub);
        _context.Update(mas);
        _context.SaveChanges();
    }

    public void AssignAccountToPublisher(Guid publisher, Guid account)
    {
        var pub = _context.MessagePublishers.Include(x => x.Accounts).FirstOrDefault(x => x.Id.Equals(publisher)) ?? throw SearchException<BaseMessagePublisher>.NotFound();
        var acc = _context.PublisherAccounts.FirstOrDefault(x => x.Id.Equals(account)) ?? throw SearchException<BasePublisherAccount>.NotFound();

        if (pub.Accounts.Any(x => x.Id.Equals(acc.Id)))
            throw AssignmentException.DuplicateAssignment();
        
        pub.Accounts.Add(acc);
        _context.Update(pub);
        _context.SaveChanges();
    }

    public void AssignEmployeeAccountToPublisher(Guid publisher, Guid account)
    {
        var pub = _context.PublisherAccounts.Include(x => x.Subscribers).FirstOrDefault(x => x.Id.Equals(publisher)) ?? throw SearchException<BasePublisherAccount>.NotFound();
        var acc = _context.EmployeeAccounts.OfType<EmployeeAccount>().FirstOrDefault(x => x.Id.Equals(account)) ?? throw SearchException<EmployeeAccount>.NotFound();
        
        if (pub.Subscribers.Any(x => x.Id.Equals(acc.Id)))
            throw AssignmentException.DuplicateAssignment();
        
        pub.Subscribers.Add(acc);
        _context.Update(pub);
        _context.SaveChanges();
    }
}