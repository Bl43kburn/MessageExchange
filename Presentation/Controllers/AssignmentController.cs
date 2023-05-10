using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Services;
using DataAccessLayer.Models.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.AssignmentModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    private IAssignmentService _service;

    public AssignmentController(IAssignmentService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    [Route("SubordinateAssignment")]
    public Task<ActionResult<Unit>> AssignSubordinate([FromBody] AssignmentModel model)
    {
        _service.AssignSubordinate(model.owner, model.assignee);
        return Task.FromResult<ActionResult<Unit>>(Ok(Unit.Value));
    }

    [HttpPost]
    [Route("PublisherAccountAssignment")]
    public Task<ActionResult<Unit>> AssignAccount([FromBody] AssignmentModel model)
    {
        _service.AssignAccountToPublisher(model.owner, model.assignee);
        return Task.FromResult<ActionResult<Unit>>(Ok(Unit.Value));
    }

    [HttpPost]
    [Route("EmployeePublisherAccount")]
    public Task<ActionResult<Unit>> AssignPublisherAccount([FromBody] AssignmentModel model)
    {
        _service.AssignEmployeeAccountToPublisher(model.owner, model.assignee);
        return Task.FromResult<ActionResult<Unit>>(Ok(Unit.Value));
    }
}