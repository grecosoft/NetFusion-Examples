using Examples.Messaging.Domain.Events;
using Examples.Messaging.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Messaging;

namespace Examples.Messaging.WebApi.Controllers;

[ApiController, Route("api/messaging")]
public class MessageController : ControllerBase
{
    private readonly IMessagingService _messaging;

    public MessageController(IMessagingService messaging)
    {
        _messaging = messaging;
    }

    [HttpPost("register/customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody]CustomerRegistration model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var domainEvent = new NewCustomerDomainEvent(model.FirstName, model.LastName);
        await _messaging.PublishAsync(domainEvent);
        return Ok();
    }
    
    [HttpPost("print/customer/{color}")]
    public async Task<IActionResult> PrintCustomer([FromBody]CustomerRegistration model, [FromRoute]string color)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var domainEvent = new NewCustomerDomainEvent(model.FirstName, model.LastName);
        domainEvent.Attributes.Add("print", color);
        
        await _messaging.PublishAsync(domainEvent);
        return Ok();
    }
}