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
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _service;

        public StudentController(ILogger<StudentController> logger, IStudentService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetByStudentId")]
        public async Task<ActionResult<StudentModel>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> Insert(StudentModel dto)
        {
            if (dto.UfId < 0)
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
        public async Task<ActionResult<StudentModel>> Update(StudentModel dto)
        {
            if (dto.UfId < 0)
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
        public async Task<ActionResult<StudentModel>> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
