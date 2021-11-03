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

        [HttpGet("Query", Name = "GetByQueryParams")]
        public async Task<ActionResult<DegreeCourseModel>> GetByQueryParams([FromQuery]int? degreeId, [FromQuery]int? courseId, [FromQuery]int? requirementType)
        {
            IEnumerable<DegreeCourseModel> result = new DegreeCourseModel[] { };
            if (degreeId.HasValue && courseId.HasValue && requirementType.HasValue)
                result = new DegreeCourseModel[] { await _service.GetByAllParams(degreeId.Value, courseId.Value, requirementType.Value) };
            else if (degreeId.HasValue && courseId.HasValue)
                result = new DegreeCourseModel[] { await _service.GetByIds(degreeId.Value, courseId.Value) };
            else if (degreeId.HasValue && requirementType.HasValue)
                result = await _service.GetByDegreeIdAndRequirementType(degreeId.Value, requirementType.Value);
            else if (courseId.HasValue && requirementType.HasValue)
                result = await _service.GetByCourseIdAndRequirementType(courseId.Value, requirementType.Value);
            else if (degreeId.HasValue)
                result = await _service.GetByDegreeId(degreeId.Value);
            else if (courseId.HasValue)
                result = await _service.GetByCourseId(courseId.Value);
            else if (requirementType.HasValue)
                result = await _service.GetByRequirementType(requirementType.Value);
            else
                result = await _service.GetAll();

            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        // <api-root-path>/degreecourse/degreeId=123&courseId=123
        /*[HttpGet("GetByDegreeIdCourseId/{degreeId}/{courseId}", Name = "GetDegreeCourseByDegreeAndCourseIds")]
        public async Task<ActionResult<DegreeCourseModel>> GetDegreeCourseByDegreeAndCourseIds(int degreeId, int courseId)
        {
            var result = await _service.GetByIds(degreeId, courseId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("GetByDegreeId/{degreeId}", Name = "GetDegreeCourseByDegreeId")]
        public async Task<ActionResult<DegreeCourseModel>> GetDegreeCourseByDegreeId(int degreeId)
        {
            var result = await _service.GetByDegreeId(degreeId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("GetByCourseId/{courseId}", Name = "GetDegreeCourseByCourseId")]
        public async Task<ActionResult<DegreeCourseModel>> GetDegreeCourseByCourseId(int courseId)
        {
            var result = await _service.GetByCourseId(courseId);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("GetByDegreeIdRequirementType/{degreeId}/{requirementType}", Name = "GetDegreeCourseByDegreeIdAndRequirementType")]
        public async Task<ActionResult<DegreeCourseModel>> GetDegreeCourseByDegreeIdAndRequirementType(int degreeId, int requirementType)
        {
            var result = await _service.GetByDegreeIdAndRequirementType(degreeId, requirementType);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("GetByCourseIdRequirementType/{courseId}/{requirementType}", Name = "GetDegreeCourseByCourseIdAndRequirementType")]
        public async Task<ActionResult<DegreeCourseModel>> GetDegreeCourseByCourseIdAndRequirementType(int courseId, int requirementType)
        {
            var result = await _service.GetByCourseIdAndRequirementType(courseId, requirementType);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }*/

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
