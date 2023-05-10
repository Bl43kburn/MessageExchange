using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using DataAccessLayer.Models.Employees;
using MediatR;

namespace BusinessLogicLayer.Anemic.Requests;

public class Authorize : IRequest<Guid>
{
    public Authorize(string login, string password)
    {
        Login = login;
        Password = password;
    }
    public string Login { get; set; }

    public string Password { get; set; }
}