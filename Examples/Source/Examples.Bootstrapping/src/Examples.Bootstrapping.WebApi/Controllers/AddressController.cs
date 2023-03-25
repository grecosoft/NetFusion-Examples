using Examples.Bootstrapping.CrossCut.Plugin;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Bootstrapping.WebApi.Controllers;

[ApiController, Route("api/addresses")]
public class AddressController : ControllerBase
{
    private readonly IAddressValidation _addressValidation;
        
    public AddressController(IAddressValidation addressValidation)
    {
        _addressValidation = addressValidation;
    }

    [HttpGet("allowed/{ip}")]
    public IActionResult CheckAllowedAddress([FromRoute]string ip)
    {
        var validatedBySource = _addressValidation.IsValidAddress(ip);
        if (validatedBySource == null)
        {
            return BadRequest();
        }

        return Ok(validatedBySource);
    }
}