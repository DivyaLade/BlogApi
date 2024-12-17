using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _CommentService;
        private Comment commentModel;

        public CommentController(IComment commentService)
        {
            _CommentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comment = await _CommentService.GetAll();
            if (comment == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(comment);

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveComment(Comment commentModel)
        {
            var model = await _CommentService.AddComment(commentModel);
            return Ok(model);
        }
    }
}
