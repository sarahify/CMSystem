using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StacksController : ControllerBase
    {
        private readonly IStacksService _stacksService;

        public StacksController(IStacksService stacksService)
        {
            _stacksService = stacksService;
        }

        [HttpGet("all")]
        public IActionResult GetAllStacks()
        {
            var responseDto = _stacksService.GetStacks();
            return Ok(responseDto);
        }

        [HttpGet("{stackId}/get-users")]
        public async Task<ActionResult<List<ApplicationUser>>> GetUsersByStack(string stackId)
        {
            var users = await _stacksService.GetUsersByStack(stackId);
            return Ok(users);
        }

        //[Authorize(Roles = "Facilitator, Admin")]
        //[Authorize(Policy = "can_delete")]
        [HttpDelete("{stackId}/delete")]
        public async Task<IActionResult> DeleteStack(string stackId)
        {
            var response = await _stacksService.DeleteStack(stackId);

            if (response.StatusCode == 200)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(response.ErrorMessages);
            }
        }
    }
}