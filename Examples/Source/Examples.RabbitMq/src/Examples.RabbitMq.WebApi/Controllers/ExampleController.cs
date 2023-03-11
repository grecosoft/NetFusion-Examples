using Examples.RabbitMQ.App.Repositories;
using Examples.RabbitMQ.Domain.Commands;
using Examples.RabbitMQ.Domain.Events;
using Examples.RabbitMQ.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Integration.RabbitMQ;
using NetFusion.Messaging;
using NetFusion.Messaging.Types.Attributes;

namespace Examples.RabbitMQ.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IMessagingService _messaging;
    private readonly IQueueResponseService _queueResponse;
    private readonly IPendingAutoServiceRepository _serviceRepository;

    public ExampleController(
        IMessagingService messaging, 
        IQueueResponseService queueResponse,
        IPendingAutoServiceRepository serviceRepository)
    {
        _messaging = messaging;
        _queueResponse = queueResponse;
        _serviceRepository = serviceRepository;
    }

    [HttpPost("properties/sold")]
    public async Task<IActionResult> PropertySold(PropertySoldModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var domainEvent = new PropertySold(model.Address, model.City, model.State, model.Zip)
        {
            AskingPrice = model.AskingPrice,
            SoldPrice = model.SoldPrice
        };

        await _messaging.PublishAsync(domainEvent);
        return Ok();
    }
    
    [HttpPost("auto/sales")]
    public async Task<IActionResult> AutoSales(AutoSalesModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var domainEvent = new AutoSaleCompleted(model.Make, model.Model, model.Year)
        {
            Color = model.Color,
            IsNew = model.IsNew
        };

        await _messaging.PublishAsync(domainEvent);
        return Ok();
    }
    
    [HttpPost("send/email")]
    public async Task<IActionResult> SendEmail(SendEmailModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new SendEmail(model.Subject, model.FromAddress, model.ToAddresses, model.Message);

        await _messaging.SendAsync(command);
        return Ok();
    }
    
    [HttpPost("generate/carfax/{vin}/{state}")]
    public async Task<IActionResult> GenerateCarFax(string vin, string state)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new GenerateCarFaxReport(vin, state);

        await _messaging.SendAsync(command);
        return Ok();
    }
    
    [HttpPost("auto/services/report")]
    public async Task<IActionResult> GenerateServiceReport([FromBody]AutoServiceModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new GenerateServiceReport(model.Make, model.Model, model.Year, model.Miles)
        {
            Notes = model.Notes
        };

        await _messaging.SendAsync(command);
        return Ok(command.GetCorrelationId());
    }
    
    [HttpPost("auto/services/report/complete")]
    public async Task<IActionResult> CompleteServiceReport([FromBody]ServiceReportModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pendingRequest = _serviceRepository.Get(model.CorrelationId);
        if (pendingRequest == null)
        {
            return NotFound();
        }

        var report = new ServiceReport(pendingRequest.Make, pendingRequest.Model,
            model.TotalCost,
            model.RequiredServices);


        await _queueResponse.RespondToSenderAsync(pendingRequest, report);
        _serviceRepository.Remove(model.CorrelationId);
        return Ok();
    }
    
    [HttpPost("services/configuration")]
    public async Task<IActionResult> UpdateConfiguration(ConfigurationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var domainEvent = new ConfigurationUpdated(model.MinLogLevel, model.ClearStatistics, model.RestoreAfterSeconds);
        await _messaging.PublishAsync(domainEvent);
        return Ok();
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