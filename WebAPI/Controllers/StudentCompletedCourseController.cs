using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentCompletedCourseController : ControllerBase
    {

        private readonly ILogger<StudentCompletedCourseController> _logger;
        private readonly IStudentCompletedCourseService _service;

        public StudentCompletedCourseController(ILogger<StudentCompletedCourseController> logger, IStudentCompletedCourseService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentCompletedCourseModel>> GetAll()
        {
            return await _service.GetAll();
        }

        // <api-root-path>/degreecourse/id?ufId=123&courseId=123
        [HttpGet("{id}", Name = "GetByUfAndCourseIds")]
        public async Task<ActionResult<StudentCompletedCourseModel>> GetByIds(int ufId, int courseId)
        {
            var result = await _service.GetById(ufId, courseId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StudentCompletedCourseModel>> Insert(StudentCompletedCourseModel dto)
        {
            if (dto.CourseId < 0 || dto.UfId < 0)
            {
                return BadRequest("UF Id cannot be set for insert action.");
            }

            var id = await _service.Insert(dto);
            if (id != default)
                return CreatedAtRoute("FindOne", new { UfId = id }, dto);
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<StudentCompletedCourseModel>> Update(StudentCompletedCourseModel dto)
        {
            if (dto.CourseId < 0 || dto.UfId < 0)
            {
                return BadRequest("Id should be set for insert action.");
            }

            var result = await _service.Update(dto);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        // <api-root-path>/degreecourse/<id>?ufId=123&courseId=123

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentCompletedCourseModel>> Delete(int ufId, int courseId)
        {
            var result = await _service.Delete(ufId, courseId);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
