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
    public class CourseInstanceController : ControllerBase
    {

        private readonly ILogger<CourseInstanceController> _logger;
        private readonly ICourseInstanceService _service;

        public CourseInstanceController(ILogger<CourseInstanceController> logger, ICourseInstanceService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseInstanceModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetByInstanceId")]
        public async Task<ActionResult<CourseInstanceModel>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("{semester}/{year}", Name ="GetBySemesterYear")]
        public async Task<ActionResult<CourseInstanceModel>> GetBySemesterYear(string semester, int year)
        {
            var result = await _service.GetBySemesterYear(semester, year);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CourseInstanceModel>> Insert(CourseInstanceModel dto)
        {
            if (dto.InstanceId < 0)
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
        public async Task<ActionResult<CourseInstanceModel>> Update(CourseInstanceModel dto)
        {
            if (dto.InstanceId < 0)
            {
                return BadRequest("Id should be set for insert action.");
            }

            var result = await _service.Update(dto);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseInstanceModel>> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
