namespace DataAccessLayer.Models.Accounts;

public class MasterAccount : BaseEmployeeAccount
{
    public MasterAccount(string login, string password, Guid id)
    {
        Login = login;
        Password = password;
        Id = id;
        Reports = new List<Report>();
    }

    protected MasterAccount()
    {
        Reports = new List<Report>();
    }

    public override Guid Id { get; set; }

    public virtual ICollection<Report> Reports { get; set; }
    public override string Login { get; set; }

    public override string Password { get; set; }
}