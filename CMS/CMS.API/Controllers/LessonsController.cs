using AutoMapper;
using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/lesson")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;
      

        public LessonsController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
         
        }
        [Authorize(Roles = "Facilitator, Admin")]
        [Authorize(Policy = "can_add")]
        [HttpPost("add")]
        public async Task<IActionResult> AddLesson(AddLessonDTO addLesson)
        {
            var result = await _lessonsService.AddLessonNew(addLesson);
            if(result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Roles = "Facilitator, Admin")]
        [Authorize(Policy = "can_delete")]
        [HttpDelete("{lessonid}/delete")]
        public async Task<IActionResult> DeleteLeson(string lessonid)
        {
            var result = await _lessonsService.DeleteLessonbyid(lessonid);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Authorize]
        [HttpGet("{moduleid}")]
        public async Task<IActionResult> GetLessonByModule(Modules moduleid)
        {
            var result = await _lessonsService.GetLessonByModuleAsync(moduleid);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }else if(result.StatusCode == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Authorize(Policy = "can_update")]
        [Authorize(Roles = "Facilitator, Admin")]
        [HttpPut("{lessonId}/update")]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDTO lesson, string lessonId)
        {
            var result = await _lessonsService.UpdateLesson(lesson, lessonId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}