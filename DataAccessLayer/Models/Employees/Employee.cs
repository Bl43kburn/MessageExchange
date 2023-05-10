using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace DataAccessLayer.Models.Employees;

public class Employee : BaseEmployee
{
    public Employee(string name, int age, BaseEmployeeAccount account, Guid id, Guid accountId)
    {
        FullName = name;
        Age = age;
        AccountId = accountId;
        Id = id;
    }

    protected Employee() { }

    public override string FullName { get; set; }
    public override int Age { get; set; }
    public override Guid AccountId { get; set; }
}