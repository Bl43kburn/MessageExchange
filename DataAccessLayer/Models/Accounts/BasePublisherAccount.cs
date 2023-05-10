namespace DataAccessLayer.Models.Accounts;

public abstract class BasePublisherAccount
{
    protected BasePublisherAccount()
    {
        Subscribers = new List<BaseEmployeeAccount>();
    }

    public virtual ICollection<BaseEmployeeAccount> Subscribers { get; set; }
    public abstract Guid Id { get; set; }

    public abstract string Login { get; set; }

    public abstract string Password { get; set; }
}