using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.Messages;

namespace DataAccessLayer.Models.Accounts;

public class EmployeeAccount : BaseEmployeeAccount
{
    public EmployeeAccount(string login, string password, Guid id)
    {
        Login = login;
        Password = password;
        Id = id;
        Messages = new List<Message>();
    }

    protected EmployeeAccount()
    {
        Messages = new List<Message>();
    }

    public override Guid Id { get; set; }

    public virtual ICollection<Message> Messages { get; set; }
    public override string Login { get; set; }

    public override string Password { get; set; }
}