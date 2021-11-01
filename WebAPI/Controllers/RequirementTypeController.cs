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
    public class RequirementTypeController : ControllerBase
    {

        private readonly ILogger<RequirementTypeController> _logger;
        private readonly IRequirementTypeService _service;

        public RequirementTypeController(ILogger<RequirementTypeController> logger, IRequirementTypeService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<RequirementTypeModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{type}", Name = "GetByRequirementTypeType")]
        public async Task<ActionResult<RequirementTypeModel>> GetByType(int type)
        {
            var result = await _service.GetByType(type);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<RequirementTypeModel>> Insert(RequirementTypeModel dto)
        {
            if (dto.RequirementType < 0)
            {
                return BadRequest("UF Type cannot be set for insert action.");
            }

            var type = await _service.Insert(dto);
            if (type != default)
                return CreatedAtRoute("FindOne", new { UfType = type }, dto);
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<RequirementTypeModel>> Update(RequirementTypeModel dto)
        {
            if (dto.RequirementType < 0)
            {
                return BadRequest("Type should be set for insert action.");
            }

            var result = await _service.Update(dto);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{type}")]
        public async Task<ActionResult<RequirementTypeModel>> Delete(int type)
        {
            var result = await _service.Delete(type);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
