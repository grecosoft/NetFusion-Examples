using Examples.Monitoring.App.Plugin;
using Examples.Monitoring.Infra.Plugin;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Core.Bootstrap.Container;

namespace Examples.Monitoring.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly ICompositeApp _compositeApp;
    private readonly IPendingRequestsMonitor _pendingRequests;
    private readonly ICachedItemsMonitor _cachedItems;

    public ExamplesController(
        ICompositeApp compositeApp,
        IPendingRequestsMonitor pendingRequests,
        ICachedItemsMonitor cachedItems)
    {
        _compositeApp = compositeApp;
        _pendingRequests = pendingRequests;
        _cachedItems = cachedItems;
    }

    [HttpPost("pending/requests/{numberRequests}")]
    public IActionResult SetPendingRequests(int numberRequests)
    {
        _pendingRequests.SetPendingRequests(numberRequests);
        return Ok();
    }
    
    [HttpPost("cached/items/{numberCached}")]
    public IActionResult SetCachedItems(int numberCached)
    {
        _cachedItems.SetCachedItems(numberCached);
        return Ok();
    }
    
    [HttpPut("ready-status/toggle")]
    public IActionResult ToggleReadinessState() => Ok(_compositeApp.ToggleReadyStatus());
}