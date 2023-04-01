using Examples.MongoDB.App.Repositories;
using Examples.MongoDB.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Examples.MongoDB.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateInfoController : ControllerBase
{
    private IStateInfoRepository StateInfoRep { get; }

    public StateInfoController(IStateInfoRepository stateInfoRep)
    {
        StateInfoRep = stateInfoRep;
    }

    [HttpPost]
    public Task<string> AddStateInfo([FromBody]StateInfo stateInfo)
    {
        return StateInfoRep.Add(stateInfo);
    }

    [HttpGet("{state}")]
    public async Task<IActionResult> GetStateInfo(string state)
    {
        var entity = await StateInfoRep.Read(state);
        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }
}