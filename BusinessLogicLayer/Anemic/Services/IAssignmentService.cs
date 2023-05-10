using DataAccessLayer.Models.Employees;

namespace BusinessLogicLayer.Anemic.Services;

public interface IAssignmentService
{
    void AssignSubordinate(Guid master, Guid subordinate);

    void AssignAccountToPublisher(Guid publisher, Guid account);

    void AssignEmployeeAccountToPublisher(Guid publisher, Guid account);
}