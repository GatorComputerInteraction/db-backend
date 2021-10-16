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
    public class StudentScheduleController : ControllerBase
    {

        private readonly ILogger<StudentScheduleController> _logger;
        private readonly IStudentScheduleService _service;

        public StudentScheduleController(ILogger<StudentScheduleController> logger, IStudentScheduleService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentScheduleModel>> GetAll()
        {
            return await _service.GetAll();
        }

        // <api-root-path>/degreecourse/id?ufId=123&instanceId=123
        [HttpGet("{id}", Name = "GetByUfAndInstanceIds")]
        public async Task<ActionResult<StudentScheduleModel>> GetByIds(int ufId, int instanceId)
        {
            var result = await _service.GetById(ufId, instanceId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StudentScheduleModel>> Insert(StudentScheduleModel dto)
        {
            if (dto.InstanceId < 0 || dto.UfId < 0)
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
        public async Task<ActionResult<StudentScheduleModel>> Update(StudentScheduleModel dto)
        {
            if (dto.InstanceId < 0 || dto.UfId < 0)
            {
                return BadRequest("Id should be set for insert action.");
            }

            var result = await _service.Update(dto);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        // <api-root-path>/degreecourse/<id>?ufId=123&instanceId=123

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentScheduleModel>> Delete(int ufId, int instanceId)
        {
            var result = await _service.Delete(ufId, instanceId);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
