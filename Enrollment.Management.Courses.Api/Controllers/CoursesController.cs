using Enrollment.Management.Courses.Domain.Dtos;
using Enrollment.Management.Courses.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enrollment.Management.Courses.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ILogger<CoursesController> logger, ICoursesService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all-courses")]
        [ProducesResponseType(typeof(IEnumerable<CursosDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<CursosDto>>> GetAllCourses()
        {
            var result = await _service.GetAllCoursesAsync();

            if (result.Any()) return Ok(result);

            _logger.LogInformation("Courses not found");
            return NotFound("Courses not found");
        }

        [HttpGet("get-course-by-id/{id:int}")]
        [ProducesResponseType(typeof(CursosDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CursosDto>> GetCourseById(int id)
        {
            var result = await _service.GetCourseByIdAsync(id);

            if (result != null) return Ok(result);

            _logger.LogInformation("Course with id {Id} not found", id);
            return NotFound($"Course with {id} not found");
        }

        [HttpPost("create-course")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CursosDto>> CreateCourse([FromBody] CursosDto cursosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.CreateCourseAsync(cursosDto);

            if (result) return Ok("Course created with success");

            _logger.LogInformation("Course not created");
            return BadRequest("Course creating Student");
        }

        [HttpPut("update-course")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateCourse([FromBody] CursosDto cursosDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid");

            var result = await _service.UpdateCourseAsync(cursosDto);

            if (result) return Ok("Course update with success");

            _logger.LogInformation("Course not update");
            return BadRequest("Error update Course");
        }

        [HttpDelete("delete-course/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CursosDto>> DeleteCourse(int id)
        {
            var result = await _service.DeleteCourseAsync(id);

            if (result) return Ok($"Student with {id} deleted with success");

            _logger.LogInformation("Student with {Id} not remove", id);
            return BadRequest($"Student with {id} not remove");
        }
    }
}
