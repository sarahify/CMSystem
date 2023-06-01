using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.Entities;
using CMS.DATA.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly IQuizesService _quizesService;

        public QuizesController(IQuizesService quizesService)
        {
            _quizesService = quizesService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetAllQuiz()
        {
            try
            {
                return Ok(await _quizesService.GetQuizAysnc());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuizById(string quizId)
        {
            try
            {
                return Ok(await _quizesService.GetQuizByIdAsync(quizId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("lesson/{lessonId}")]
        public async Task<ActionResult<Quiz>> GetQuizByLessonId(string lessonId)
        {
            try
            {
                return Ok(await _quizesService.GetByLesson(lessonId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Quiz>> GetQuizByUserId(string userId)
        {
            try
            {
                return Ok(await _quizesService.GetByUser(userId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreiving data from the database");
            }
        }



        [HttpPost("add")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> AddQuiz([FromBody] AddQuizDto addQuizDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addQuiz = await _quizesService.AddQuiz(addQuizDto);
            if (addQuiz.StatusCode == 200)
            {
                return Ok(addQuiz);
            }
            else if (addQuiz.StatusCode == 400)
            {
                return NotFound(addQuiz);
            }
            else
            {
                return BadRequest(addQuiz);
            }
        }


        [HttpPatch("{quizId}/update")]
        public async Task<ActionResult<ResponseDto<AddQuizDto>>> UpdateQuiz(string quizId, [FromBody] UpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateQuiz = await _quizesService.UpdateQuiz(quizId, updateDto);
            if (updateQuiz.StatusCode == 200)
            {
                return Ok(updateQuiz);
            }
            else if (updateQuiz.StatusCode == 400)
            {
                return NotFound(updateQuiz);

            }
            else
            {
                return BadRequest(updateQuiz);
            }
        }

        [HttpDelete("{quizId}/delete")]
        public async Task<ActionResult<ResponseDto<bool>>> DeleteQuiz(string quizId)
        {

            var DeleteQuiz = await _quizesService.DeleteQuiz(quizId);

            if (DeleteQuiz.StatusCode == 200)
            {
                return Ok(DeleteQuiz);
            }
            else if (DeleteQuiz.StatusCode == 400)
            {
                return NotFound(DeleteQuiz);

            }
            else
            {
                return BadRequest(DeleteQuiz);
            }

        }
    }
}
