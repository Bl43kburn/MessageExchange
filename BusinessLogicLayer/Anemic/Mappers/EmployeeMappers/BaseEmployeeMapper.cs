using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.Employees;

namespace BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;

public static class BaseEmployeeMapper
{
    public static BaseEmployeeDTO AsDto(this BaseEmployee employee)
        => new BaseEmployeeDTO(employee.FullName, employee.Age, employee.Id, employee.AccountId);
}