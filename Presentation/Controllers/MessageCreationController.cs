using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.CreationModels.MessageModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageCreationController : ControllerBase
{
    private readonly ICreationService _service;

    public MessageCreationController(ICreationService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("MessengerMessage")]
    public Task<ActionResult<MessengerMessageDTO>> CreateMessengerMessage([FromBody] MessageModel model)
    {
        var message = _service.CreateMessengerMessage(model.account, model.publisher, model.title, model.body, model.creationDate);
        return Task.FromResult<ActionResult<MessengerMessageDTO>>(Ok(message));
    }

    [HttpPost]
    [Route("PhoneMessage")]
    public Task<ActionResult<PhoneMessageDTO>> CreatePhoneMessage([FromBody] MessageModel model)
    {
        var message = _service.CreateSmsMessage(model.account, model.publisher, model.title, model.body, model.creationDate);
        return Task.FromResult<ActionResult<PhoneMessageDTO>>(Ok(message));
    }

    [HttpPost]
    [Route("EmailMessage")]
    public Task<ActionResult<EmailMessageDTO>> CreateEmailMessage([FromBody] MessageModel model)
    {
        var message = _service.CreateEmailMessage(model.account, model.publisher, model.title, model.body, model.creationDate);
        return Task.FromResult<ActionResult<EmailMessageDTO>>(Ok(message));
    }
}