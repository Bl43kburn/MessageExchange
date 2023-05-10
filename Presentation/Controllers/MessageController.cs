using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    [Route("Aggregate")]
    public Task<ActionResult<IEnumerable<BaseMessageDTO>>> Aggregate(Guid sessionId)
    {
        var request = new AggregateMessages(sessionId);
        var result = _mediator.Send(request);

        return Task.FromResult<ActionResult<IEnumerable<BaseMessageDTO>>>(Ok(result));
    }

    [HttpPost]
    [Route("MarkProcessed")]
    public Task<ActionResult<Unit>> MarkProcessed(Guid sessionId, Guid messageId)
    {
        var request = new MarkProcessed(sessionId, messageId);
        var result = _mediator.Send(request);

        return Task.FromResult<ActionResult<Unit>>(Ok(result));
    }
}