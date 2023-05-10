using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.Services;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.CreationModels.AccountModels;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherAccountCreationController : ControllerBase
{
    private readonly ICreationService _service;

    public PublisherAccountCreationController(ICreationService service)
    {
        _service = service;
    }

    [HttpPost]
    public Task<ActionResult<PublisherAccountDTO>> CreatePublisherAccount([FromBody] PublisherAccountModel model)
    {
        var account = _service.CreatePublisherAccount(model.login, model.password);
        return Task.FromResult<ActionResult<PublisherAccountDTO>>(Ok(account));
    }
}