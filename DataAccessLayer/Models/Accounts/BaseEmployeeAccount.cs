using DataAccessLayer.Models.Employees;
using DataAccessLayer.Models.Messages;

namespace DataAccessLayer.Models.Accounts;

public abstract class BaseEmployeeAccount
{
    protected BaseEmployeeAccount()
    { }

    public abstract Guid Id { get; set; }

    public abstract string Login { get; set; }

    public abstract string Password { get; set; }
}