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
    public class PeriodController : ControllerBase
    {

        private readonly ILogger<PeriodController> _logger;
        private readonly IPeriodService _service;

        public PeriodController(ILogger<PeriodController> logger, IPeriodService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PeriodModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetPeriodByPeriodId")]
        public async Task<ActionResult<PeriodModel>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PeriodModel>> Insert(PeriodModel dto)
        {
            if (dto.PeriodId < 0)
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
        public async Task<ActionResult<PeriodModel>> Update(PeriodModel dto)
        {
            if (dto.PeriodId < 0)
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
        public async Task<ActionResult<PeriodModel>> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
