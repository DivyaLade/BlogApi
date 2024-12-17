using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _AuthorService;
        public AuthorController(IAuthor authorService)
        {
            _AuthorService = authorService;
        }


        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _AuthorService.GetById(id);
            if (author == null)
                return NotFound("Record Not Found");
            return Ok(author);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveAuthor(Author authorModel)
        {
            var model = await _AuthorService.AddAuthor(authorModel);
            return Ok(model);
        }


    }
}

