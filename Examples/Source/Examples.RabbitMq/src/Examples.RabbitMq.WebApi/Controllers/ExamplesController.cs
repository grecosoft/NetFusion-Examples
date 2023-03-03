using Examples.RabbitMq.Domain.Commands;
using Examples.RabbitMq.Domain.Events;
using Examples.RabbitMq.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Messaging;
using NetFusion.Messaging.Types.Attributes;

namespace Examples.RabbitMq.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly IMessagingService _messaging;

    public ExamplesController(
        IMessagingService messaging)
    {
        _messaging = messaging ?? throw new ArgumentNullException(nameof(messaging));
    }

    [HttpPost("property/sales")]
    public Task RecordPropertySale([FromBody]PropertySold propertyEvent)
    {
        propertyEvent.SetRouteKey(propertyEvent.State);
        return _messaging.PublishAsync(propertyEvent);
    }
    
    [HttpPost("auto/sales")]
    public Task RecordAutoSale([FromBody]AutoSaleCompleted salesCompleted)
    {
        return _messaging.PublishAsync(salesCompleted);
    }
    
    [HttpPost("send/email")]
    public Task SendEmail([FromBody]SendEmail command)
    {
        return _messaging.SendAsync(command);
    }
    
    [HttpPost("generate/carfax/{vin}/{state}")]
    public Task GenerateCarFax([FromRoute] string vin, [FromRoute] string state)
    {
        var command = new GenerateCarFax(vin, state);
        return _messaging.SendAsync(command);
    }

    [HttpPost("calculations/auto/tax")]
    public async Task<IActionResult> CalculateAutoTax([FromBody] AutoTax model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var command = new CalculateAutoTax(model.Vin, model.ZipCode);
        var result = await _messaging.SendAsync(command);
        return Ok(result);
    }

    [HttpPost("calculations/property/tax")]
    public async Task<IActionResult> CalculatePropertyTax([FromBody] PropertyTax model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var command = new CalculatePropertyTax(model.Address, model.City, model.State, model.Zip);
        var result = await _messaging.SendAsync(command);
        return Ok(result);
    }
    
}