using Demo.App.Services;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Bootstrap.Container;

namespace Demo.WebApi.Controllers;

[Route("api/health-monitor")]
public class HealthMonitorController : ControllerBase
{
    private readonly ICompositeApp _compositeApp;
    private readonly IRunningServicesMonitor _servicesMonitor;
    private readonly IRunningRepositoryMonitor _repositoryMonitor;
    
    public HealthMonitorController(
        ICompositeApp compositeApp,
        IRunningServicesMonitor serviceMonitor,
        IRunningRepositoryMonitor repositoryMonitor)
    {
        _compositeApp = compositeApp;
        _servicesMonitor = serviceMonitor;
        _repositoryMonitor = repositoryMonitor;
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
    
    [HttpPost("repositories/{repositoryId}")]
    public IActionResult AddRepository([FromRoute]string repositoryId)
    {
        _repositoryMonitor.AddRunningRepo(repositoryId);
        return Ok();
    }

    [HttpDelete("repositories")]
    public IActionResult RemoveRepository()
    {
        string serviceId = _repositoryMonitor.RemoveRunningRepo();
        if (serviceId == null)
        {
            return NotFound();
        }

        return Ok(serviceId);
    }

    [HttpPut("ready-status/toggle")]
    public IActionResult ToggleReadinessState() => Ok(_compositeApp.ToggleReadyStatus());
}