using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.CreationModels.AccountModels;
using Presentation.Models.CreationModels.PublisherModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherCreationController : ControllerBase
{
    private readonly ICreationService _service;

    public PublisherCreationController(ICreationService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    [Route("Phone")]
    public Task<ActionResult<PhoneMessagePublisherDTO>> CreateMessengerPublisher([FromBody] PhonePublisherModel model)
    {
        var publisher = _service.CreatePhonePublisher(model.number);
        return Task.FromResult<ActionResult<PhoneMessagePublisherDTO>>(Ok(publisher));
    }

    [HttpPost]
    [Route("Messenger")]
    public Task<ActionResult<MessengerMessagePublisherDTO>> CreateMessengerPublisher([FromBody] MessengerPublisherModel model)
    {
        var publisher = _service.CreateMessagePublisher(model.userId);
        return Task.FromResult<ActionResult<MessengerMessagePublisherDTO>>(Ok(publisher));
    }

    [HttpPost]
    [Route("Email")]
    public Task<ActionResult<EmailMessagePublisherDTO>> CreateEmailPublisher([FromBody] EmailPublisherModel model)
    {
        var publisher = _service.CreateMessagePublisher(model.email);
        return Task.FromResult<ActionResult<EmailMessagePublisherDTO>>(Ok(publisher));
    }
}