using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using DataAccessLayer.Models.Employees;

namespace BusinessLogicLayer.Anemic.Mappers.EmployeeMappers;

public static class MasterMapper
{
    public static MasterDTO AsDto(this Master master)
        => new MasterDTO(master.FullName, master.Age, master.Id, master.AccountId, master.Subordinates.Select(x => x.AsDto()));
}