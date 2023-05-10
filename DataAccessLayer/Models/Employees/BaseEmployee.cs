using DataAccessLayer.Models.Accounts;

namespace DataAccessLayer.Models.Employees;

public abstract class BaseEmployee
{
    public BaseEmployee(Guid id)
    {
        Id = id;
    }

    public BaseEmployee() { }

    public abstract string FullName { get; set; }
    public abstract int Age { get; set; }
    public Guid Id { get; set; }
    public abstract Guid AccountId { get; set; }
}