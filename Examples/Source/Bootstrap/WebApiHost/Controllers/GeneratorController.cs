using System.Collections.Generic;
using System.Linq;
using Core.Component;
using Microsoft.AspNetCore.Mvc;

namespace WebApiHost.Controllers
{
    [Route("api/generators")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly IEnumerable<INumberGenerator> _generators;

        public GeneratorController(
            IEnumerable<INumberGenerator> generators)
        {
            _generators = generators;
        }

        [HttpGet("numbers")]
        public int[] GenerateNumbers()
        {
            var numbers =_generators.Select(g => g.GenerateNumber())
                .ToArray();

            return numbers;
        }
    }
}
