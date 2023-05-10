using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.Requests;
using BusinessLogicLayer.Anemic.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.CreationModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private IMediator _mediator;

    private ICreationService _service;

    public ReportController(IMediator mediator, ICreationService service)
    {
        _mediator = mediator;
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    [Route("CreateReport")]
    public Task<ActionResult<ReportDTO>> CreateReport([FromBody] ReportCreationModel model)
    {
        var report = _service.CreateReport(model.sessionId, model.durationStart, model.durationEnd, model.creationDate);
        return Task.FromResult<ActionResult<ReportDTO>>(Ok(report));
    }

    [HttpPost]
    [Route("GetReports")]
    public Task<ActionResult<IEnumerable<ReportDTO>>> GetReports(Guid sessionId, DateTime startingDate)
    {
        var request = new GetReportsByDate(startingDate, sessionId);
        var response = _mediator.Send(request);

        return Task.FromResult<ActionResult<IEnumerable<ReportDTO>>>(Ok(response));
    }
}