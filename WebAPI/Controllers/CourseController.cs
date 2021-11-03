﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _service;

        public CourseController(ILogger<CourseController> logger, ICourseService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetCourseByCourseId")]
        public async Task<ActionResult<CourseModel>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> Insert(CourseModel dto)
        {
            if (dto.CourseId < 0)
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
        public async Task<ActionResult<CourseModel>> Update(CourseModel dto)
        {
            if (dto.CourseId < 0)
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
        public async Task<ActionResult<CourseModel>> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
