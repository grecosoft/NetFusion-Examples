using Examples.ServiceBus.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Core.Bootstrap.Container;
using NetFusion.Messaging;

namespace Examples.ServiceBus.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly ICompositeApp _compositeApp;
    private readonly IMessagingService _messaging;

    public ExamplesController(ICompositeApp compositeApp, IMessagingService messaging)
    {
        _compositeApp = compositeApp;
        _messaging = messaging;
    }

    [HttpGet("host-plugin")]
    public IActionResult GetHostPlugin() => Ok(_compositeApp.HostPlugin);
    
    [HttpPost("publish")]
    public async Task<IActionResult> Publish()
    {
        var command = new GenerateCarFax("Honda", "Accord");
        await _messaging.SendAsync(command);

        return Ok();
    }
}