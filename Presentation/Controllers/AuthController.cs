using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Models.OtherModels;

namespace Presentation.Controllers;

[ApiController]
[Route("user/homepage")]
public class AuthController : ControllerBase
{
    private IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Login")]
    public Task<ActionResult<Guid>> Auth([FromBody] AuthModel model)
    {
        Authorize mod = new Authorize(model.login, model.password);
        var result = _mediator.Send(mod);

        return Task.FromResult<ActionResult<Guid>>(Ok(result));
    }

    [HttpPost]
    [Route("Logout")]
    public Task<ActionResult<Unit>> Auth(Guid sessionId)
    {
        var end = new EndSession(sessionId);
        var result = _mediator.Send(end);

        return Task.FromResult<ActionResult<Unit>>(Ok(result));
    }
}