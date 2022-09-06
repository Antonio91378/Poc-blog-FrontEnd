
using System.Net;
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Blog.BackEnd.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("/posts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayPosts()
        {
            var posts = await _postService.DisplayAllPostsAsync();
            if (posts.Count == 0)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Posts not found";
                problemDetails.Detail = "It wasn't possible to find posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }

            return Ok(posts);
        }
        [HttpGet]
        [Route("/posts/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DisplayPosts(string id)
        {
            var post = await _postService.DisplayPostByIdAsync(id);
            if (post is null)
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Type = "NotFound";
                problemDetails.Title = "Post not found";
                problemDetails.Detail = "It wasn't possible to find the specific posts";
                problemDetails.Instance = HttpContext.Request.Path;
                return NotFound(problemDetails);
            }
            return Ok(post);
        }
        [HttpPost]
        [Route("/posts")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePostAsync([FromBody] Post post)
        {
            if (post != null)
            {
                await _postService.CreatePostAsync(post);
                return StatusCode((int)HttpStatusCode.Created, post);
            }
            else
            {
                var problemDetails = new ProblemDetails();
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Type = "BadRequest";
                problemDetails.Title = "Post can't not be null";
                problemDetails.Detail = "It wasn't possible to create a post";
                problemDetails.Instance = HttpContext.Request.Path;
                return BadRequest(problemDetails);
            }
        }
    }
}
