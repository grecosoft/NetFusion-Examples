using Examples.Bootstrapping.CrossCut.Plugin;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Bootstrapping.WebApi.Controllers;

[ApiController, Route("api/ranges")]
public class RangeController : ControllerBase
{
    private readonly ICheckValidRange _validRange;
        
    public RangeController(ICheckValidRange validRange)
    {
        _validRange = validRange;
    }
        
    [HttpPost("check/{value}")]
    public IActionResult Check([FromRoute]int value)
    {
        var range = _validRange.IsValidRange(value);
        if (range == null)
        {
            return BadRequest($"{value} is not within a valid range");
        }

        return Ok(new
        {
            value,
            minValue = range.Item1,
            maxValue = range.Item2
        });
    }
}