using Microsoft.AspNetCore.Mvc;
using PublishService.Common.Constants;
using PublishService.Interfaces;

namespace PublishService.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishController : ControllerBase
{
    private readonly ILogger<PublishController> _logger;
    private readonly IMessageService _messageService;

    public PublishController(ILogger<PublishController> logger, IMessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost]
    [Route("customer")]
    public async Task<IActionResult> CreateCustomer(Customer request)
    {
       var result = await _messageService.PublishMessage(request, Queues.CustomerCreated);

       if(result.IsFailure)
            return UnprocessableEntity();

       return Ok("Request recieved.");
    }
}

public class Customer
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}