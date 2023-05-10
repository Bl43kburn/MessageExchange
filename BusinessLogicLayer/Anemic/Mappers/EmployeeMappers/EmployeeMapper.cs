using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.Employees;

namespace BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;

public static class EmployeeMapper
{
    public static EmployeeDTO AsDto(this Employee employee)
        => new EmployeeDTO(employee.FullName, employee.Age, employee.Id, employee.AccountId);
}