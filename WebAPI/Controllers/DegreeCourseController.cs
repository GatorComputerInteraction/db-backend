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
    public class DegreeCourseController : ControllerBase
    {

        private readonly ILogger<DegreeCourseController> _logger;
        private readonly IDegreeCourseService _service;

        public DegreeCourseController(ILogger<DegreeCourseController> logger, IDegreeCourseService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<DegreeCourseModel>> GetAll()
        {
            return await _service.GetAll();
        }

        // <api-root-path>/degreecourse/id?degreeId=123&courseId=123
        [HttpGet("{id}", Name = "GetByDegreeAndCourseIds")]
        public async Task<ActionResult<DegreeCourseModel>> GetByIds(int degreeId, int courseId)
        {
            var result = await _service.GetById(degreeId, courseId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<DegreeCourseModel>> Insert(DegreeCourseModel dto)
        {
            if (dto.CourseId < 0 || dto.DegreeId < 0)
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
        public async Task<ActionResult<DegreeCourseModel>> Update(DegreeCourseModel dto)
        {
            if (dto.CourseId < 0 || dto.DegreeId < 0)
            {
                return BadRequest("Id should be set for insert action.");
            }

            var result = await _service.Update(dto);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        // <api-root-path>/degreecourse/<id>?degreeId=123&courseId=123

        [HttpDelete("{id}")]
        public async Task<ActionResult<DegreeCourseModel>> Delete(int degreeId, int courseId)
        {
            var result = await _service.Delete(degreeId, courseId);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
