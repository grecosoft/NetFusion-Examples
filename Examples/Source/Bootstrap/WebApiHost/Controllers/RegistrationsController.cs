using Core.Component;
using Microsoft.AspNetCore.Mvc;

namespace WebApiHost.Controllers
{
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
}
