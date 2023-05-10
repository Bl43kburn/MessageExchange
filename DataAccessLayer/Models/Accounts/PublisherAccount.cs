namespace DataAccessLayer.Models.Accounts;

public class PublisherAccount : BasePublisherAccount
{
    public PublisherAccount(string login, string password, Guid id)
    {
        Login = login;
        Password = password;
        Id = id;
        Subscribers = new List<BaseEmployeeAccount>();
    }

    protected PublisherAccount() { }
    public override string Login { get; set; }

    public override string Password { get; set; }

    public override Guid Id { get; set; }
}