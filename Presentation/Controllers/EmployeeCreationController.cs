using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.CreationModels.EmployeeModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonCreationController : ControllerBase
{
    private readonly ICreationService _service;

    public PersonCreationController(ICreationService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    [Route("employee")]
    public Task<ActionResult<EmployeeDTO>> CreateEmployee([FromBody] PersonModel model)
    {
        var employee = _service.CreateEmployee(model.fullName, model.age, model.login, model.password);
        return Task.FromResult<ActionResult<EmployeeDTO>>(Ok(employee));
    }

    [HttpPost]
    [Route("master")]
    public Task<ActionResult<MasterDTO>> CreateMaster([FromBody] PersonModel model)
    {
        var master = _service.CreateMaster(model.fullName, model.age, model.login, model.password);
        return Task.FromResult<ActionResult<MasterDTO>>(Ok(master));
    }
}