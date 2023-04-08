using Enrollment.Management.Students.Domain.Dtos;
using Enrollment.Management.Students.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enrollment.Management.Students.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class StudentController : Controller
    {
        private readonly IStudentsService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentsService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all-students")]
        [ProducesResponseType(typeof(IEnumerable<AlunosDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<AlunosDto>>> GetAllStudents()
        {
            var result = await _service.GetAllStudentsAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Students not found");
            return NotFound("Students not found");
        }

        [HttpGet("get-student-by-id/{id:int}")]
        [ProducesResponseType(typeof(AlunosDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AlunosDto>> GetStudentById(int id)
        {
            var result = await _service.GetStudentByIdAsync(id);

            if (result != null) return Ok(result);

            _logger.LogInformation("Student with id {Id} not found", id);
            return NotFound($"Student with {id} not found");
        }

        [HttpPost("create-student")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AlunosDto>> CreateStudents([FromBody] AlunosDto alunosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.CreateStudentAsync(alunosDto);

            if (result) return Ok("Student created with success");

            _logger.LogInformation("Student not created");
            return BadRequest("Error creating Student");
        }

        [HttpPut("update-student")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateStudents([FromBody] AlunosDto alunosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.UpdateStudentAsync(alunosDto);

            if (result) return Ok("Student update with success");

            _logger.LogInformation("Student not update");
            return BadRequest("Error update Student");
        }

        [HttpDelete("delete-student/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AlunosDto>> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudentAsync(id);

            if (result) return Ok($"Student with {id} deleted with success");

            _logger.LogInformation("Student with {Id} not remove", id);
            return BadRequest($"Student with {id} not remove");
        }
    }
}
