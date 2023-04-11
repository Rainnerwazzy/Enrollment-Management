using Enrollment.Management.Registration.Domain.Dtos;
using Enrollment.Management.Registration.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _service;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistrationService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all-registrations")]
        [ProducesResponseType(typeof(IEnumerable<MatriculasDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<MatriculasDto>>> GetAllRegistrations()
        {
            var result = await _service.GetAllRegistrationsAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Registrations not found");
            return NotFound("Registrations not found");
        }

        [HttpGet("get-registration-by-id/{id:int}")]
        [ProducesResponseType(typeof(MatriculasDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MatriculasDto>> GetRegistrationById(int id)
        {
            var result = await _service.GetRegistrationByIdAsync(id);

            if (result != null) return Ok(result);

            _logger.LogInformation("Registration with id {Id} not found", id);
            return NotFound($"Registration with {id} not found");
        }

        [HttpPost("create-registration")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MatriculasDto>> CreateRegistration([FromBody] MatriculasDto matriculasDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.CreateRegistrationAsync(matriculasDto);

            if (result) return Ok("Registration created with success");

            _logger.LogInformation("Registration not created");
            return BadRequest("Registration creating Student");
        }

        [HttpPut("update-registration")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateRegistration([FromBody] MatriculasDto matriculasDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.UpdateRegistrationAsync(matriculasDto);

            if (result) return Ok("Registration update with success");

            _logger.LogInformation("Registration not update");
            return BadRequest("Error update Registration");
        }

        [HttpDelete("delete-registration/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MatriculasDto>> DeleteRegistration(int id)
        {
            var result = await _service.DeleteRegistrationAsync(id);

            if (result) return Ok($"Registration with {id} deleted with success");

            _logger.LogInformation("Registration with {Id} not remove", id);
            return BadRequest($"Registration with {id} not remove");
        }
    }
}
