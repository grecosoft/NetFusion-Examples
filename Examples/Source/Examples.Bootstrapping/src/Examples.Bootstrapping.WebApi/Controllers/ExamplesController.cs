using Microsoft.AspNetCore.Mvc;

namespace Examples.Bootstrapping.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly ICompositeApp _compositeApp;
    
    public ExamplesController(ICompositeApp compositeApp)
    {
        _compositeApp = compositeApp;
    }

    [HttpGet("host-plugin")]
    public IActionResult GetHostPlugin() => Ok(_compositeApp.HostPlugin);
}