using DataAccessLayer.Models.Employees;

namespace DataAccessLayer.Models;

public class ActiveSessionModel
{
    public ActiveSessionModel(BaseEmployee employee)
    {
        EmployeeId = employee.Id;
        Id = Guid.NewGuid();
        EmployeeAccountId = employee.AccountId;
    }

    protected ActiveSessionModel() { }

    public Guid EmployeeId { get; set; }

    public Guid EmployeeAccountId { get; set; }
    public Guid Id { get; set; }
}