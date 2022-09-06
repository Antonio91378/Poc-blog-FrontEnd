
using System.Net;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Blog.BackEnd.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayUsers()
        {
            var users = await _userService.DisplayAllUsersAsync();
            if (users.Count == 0)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Users not found";
                problemDetails.Detail = "It wasn't possible to find users";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(users);
        }
        [HttpGet]
        [Route("/users/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayUsers(string id)
        {
            var user = await _userService.DisplayUserByIdAsync(id);
            if (user is null)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "User not found";
                problemDetails.Detail = "It wasn't possible to find the specific users";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }
            return Ok(user);
        }
        [HttpPost]
        [Route("/users")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            if (user != null)
            {
                await _userService.CreateUserAsync(user);
                return StatusCode((int)HttpStatusCode.Created, user);
            }
            else
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Type = "BadRequest";
                problemDetails.Title = "User can't not be null";
                problemDetails.Detail = "It wasn't possible to create a user";
                problemDetails.Instance = HttpContext.Request.Path;
                return BadRequest(problemDetails);
            }
        }
    }
}
