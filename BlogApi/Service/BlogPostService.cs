using BlogApi.Context;
using BlogApi.Entities;
using BlogApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogApi.Service
{
    public class BlogPostService: IBlogPost
    {
        private readonly BlogDbContext _dbContext;
        public BlogPostService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BlogPost>>GetAll()
        {
            return await _dbContext.Posts.ToListAsync();
        }
        public async Task<BlogPost?>GetById(int id)
        {
            return await _dbContext.Posts.FirstOrDefaultAsync(blg => blg.Id == id);
        }
        public async Task<BlogPost?>AddBlogPosts(BlogPost blog)
        {
            var addBlogPosts = new BlogPost()
            {
                Title = blog.Title,
                Content = blog.Content,
                AuthorId = blog.AuthorId,
                CommentId = blog.CommentId,
            };
            _dbContext.Posts.Add(addBlogPosts);
            var result = await _dbContext.SaveChangesAsync();
            return result >=0 ? addBlogPosts : null;
        }
        public async Task<BlogPost?>UpdateBlogPosts(int id, BlogPost blog)
        {
            var obj = await _dbContext.Posts.FirstOrDefaultAsync(Index => Index.Id == id);
            if (obj != null)
            {
                obj.Title = blog.Title;
                obj.Content = blog.Content;
                obj.AuthorId = blog.AuthorId;
                obj.CommentId = blog.CommentId;
                var result = await _dbContext.SaveChangesAsync();
                return result >=0 ? obj : null;
            }
            return null;
        }
        public async Task<bool> DeleteById(int id)
        {
            var hero = await _dbContext.Posts.FirstOrDefaultAsync(Index=>Index.Id == id);
            if(hero != null)
            {
                _dbContext.Posts.Remove(hero);
                var result = await _dbContext.SaveChangesAsync();
                return result >=0;
            }
            return false;
        }


    }
}
