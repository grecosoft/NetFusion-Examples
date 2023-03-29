using Examples.Messaging.Domain.Commands;
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

    // Example publishing a domain-event with two consumers:
    //      AmericanAutoSalesHandler
    //      GermanAutoSalesHandlers
    //
    // Two routes are defined for RegistrationEvent specifying a predicate
    // determining which makes are set to each consumer.
    [HttpPost("auto/sales")]
    public async Task<IActionResult> AutoSalesCompleted([FromBody]AutoSalesModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var domainEvt = new AutoSoldEvent(
            model.Make, 
            model.Model,
            model.Year);

        await _messaging.PublishAsync(domainEvt);
        return Ok();
    }

    [HttpPost("auto/registration")]
    public async Task<IActionResult> SubmitAutoRegistration([FromBody] AutoRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new RegisterAutoCommand(model.Make, model.Model, model.Year, model.State);
        var result = await _messaging.SendAsync(command);
        return Ok(result);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Example illustrating Message-Enrichers.
    [HttpPost("register/customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody]CustomerRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var domainEvent = new NewCustomerDomainEvent(model.FirstName, model.LastName);
        await _messaging.PublishAsync(domainEvent);
        return Ok();
    }
    
    // Example illustrating Message-Publishers 
    [HttpPost("print/customer/{color}")]
    public async Task<IActionResult> PrintCustomer([FromBody]CustomerRegistrationModel model, [FromRoute]string color)
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