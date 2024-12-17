using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPost _BlogPostService;
        public BlogPostController(IBlogPost blogPostService)
        {
            _BlogPostService = blogPostService;
        }
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var blog = await _BlogPostService.GetAll();
            if (blog == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(blog);
        }
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult>GetById(int id)
        {
            var blog = await _BlogPostService.GetById(id);
            if (blog == null)
               return NotFound("Record Not Found");
            return Ok(blog);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult>SaveBlogPosts(BlogPost blogModel)
        {
            var model = await _BlogPostService.AddBlogPosts(blogModel);
            return Ok(model);
        }
        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult>UpdateBlogPosts(int id,BlogPost updateBlogPost)
        {
            if (id != updateBlogPost.Id)
                return BadRequest("BlogPost Id mismatch");
            var updateBlogPostResult= await _BlogPostService.UpdateBlogPosts(id,updateBlogPost);
            if (updateBlogPostResult == null)
                return NotFound($"BlogPosts with Id{id}not found or update failed");
            return Ok(updateBlogPostResult);
        }
        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult>DeleteBlogPosts(int id)
        {
            var model = await _BlogPostService.DeleteById(id);
            return Ok(model);
        }
    }
}
