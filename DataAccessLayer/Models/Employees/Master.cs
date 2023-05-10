using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.Employees;

public class Master : BaseEmployee
{
    public Master(string name, int age, BaseEmployeeAccount account, Guid id, Guid accountId)
    {
        FullName = name;
        Age = age;
        Id = id;
        AccountId = accountId;
        Subordinates = new List<Employee>();
    }

    protected Master()
    {
        Subordinates = new List<Employee>();
    }

    public override string FullName { get; set; }
    public override int Age { get; set; }
    public override Guid AccountId { get; set; }
    public virtual ICollection<Employee> Subordinates { get; set; }
}