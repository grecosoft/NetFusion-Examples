using Examples.Bootstrapping.CrossCut;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Bootstrapping.WebApi.Controllers;

[ApiController, Route("api/registrations")]
public class RegistrationsController : ControllerBase
{
    private readonly IValidNumbers _validNumbers;
        
    public RegistrationsController(IValidNumbers validNumbers)
    {
        _validNumbers = validNumbers;
    }

    [HttpGet("valid/numbers")]
    public IActionResult GetValidNumbers() => Ok(_validNumbers.GetValidNumbers());
}