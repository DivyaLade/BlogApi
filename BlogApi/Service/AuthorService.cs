using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Service
{
    public class AuthorService : IAuthor
    {
        private readonly BlogDbContext _dbContext;

        public AuthorService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author?> AddAuthor(Author author)
        {
            var addAuthor = new Author()
            {

                AuthorName = author.AuthorName,
            };
            _dbContext.Authors.Add(addAuthor);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addAuthor : null;

        }

        public async Task<Author> GetById(int id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(obj => obj.AuthorId == id);
        }
    }
}
