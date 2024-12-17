using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Service
{
    public class CommentService : IComment
    {
        private readonly BlogDbContext _dbContext;

        public CommentService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Comment>> GetAll()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> AddComment(Comment comment)
        {
            var addComment = new Comment()
            {

                PostId = comment.PostId,
                Content = comment.Content,
                CommentName = comment.CommentName,
            };
            _dbContext.Comments.Add(addComment);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? addComment : null;
        }
    }
}
