using System.Threading.Tasks;
using Demo.Domain.Commands;
using Demo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Messaging;

namespace Demo.WebApi.Controllers
{
    [Route("api/registration")]
    public class RegistrationController : Controller
    {
        private readonly IMessagingService _messaging;

        public RegistrationController(
            IMessagingService messaging)
        {
            _messaging = messaging;
        }

        [HttpPost("customer")]
        public async Task<IActionResult> RegisterCustomer(
            [FromBody] CustomerModel model)
        {
            // Adapt the HTTP request model into command...
            var command = new RegisterCustomerCommand(
                model.FirstName,
                model.LastName,
                model.State);

            // Send command to application and adapt result
            // to the HTTP response:
            var status = await _messaging.SendAsync(command);
            if (!status.IsSuccess)
            {
                return BadRequest("Registration Failed");
            }

            return Ok(status);
        }
        
        [HttpPost("auto")]
        public async Task<IActionResult> RegisterAuto(
            [FromBody] AutoRegistrationModel model)
        {
            var command = new RegisterAutoCommand(
                model.Make,
                model.Model,
                model.Year,
                model.State);

            var status = await _messaging.SendAsync(command);
            if (!status.IsSuccess)
            {
                return BadRequest("Registration Failed");
            }

            return Ok(status);
        }
    }
}
