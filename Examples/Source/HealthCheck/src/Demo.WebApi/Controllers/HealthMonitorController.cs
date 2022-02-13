using Demo.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.Controllers;

[Route("api/health-monitor")]
public class HealthMonitorController : ControllerBase
{
    private readonly IRunningServicesMonitor _servicesMonitor;
    
    public HealthMonitorController(
        IRunningServicesMonitor serviceMonitor)
    {
        _servicesMonitor = serviceMonitor;
    }

    [HttpPost("services/{serviceId}")]
    public IActionResult AddService([FromRoute]string serviceId)
    {
        _servicesMonitor.AddRunningService(serviceId);
        return Ok();
    }

    [HttpDelete("services")]
    public IActionResult RemoveService()
    {
        string serviceId = _servicesMonitor.RemoveRunningService();
        if (serviceId == null)
        {
            return NotFound();
        }

        return Ok(serviceId);
    }
}