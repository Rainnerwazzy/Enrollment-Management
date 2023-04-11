using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Enrollment.Management.WebAPI.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class GatewayController : Controller
    {
        private readonly ILogger<GatewayController> _logger;

        public GatewayController(ILogger<GatewayController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-token")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GetAllRegistrations()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            return Ok(token);

            _logger.LogInformation("Registrations not found");
            return NotFound("Registrations not found");
        }    
    }
}
