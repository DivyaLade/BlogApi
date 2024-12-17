using BlogApi.Entities;

namespace BlogApi.Interface
{
    public interface IBlogPost
    {
        Task<List<BlogPost>> GetAll();
        Task<BlogPost?> GetById(int id);
        Task<BlogPost?> AddBlogPosts(BlogPost blog);
        Task<BlogPost?> UpdateBlogPosts(int id,BlogPost blog);
        Task<bool> DeleteById(int id);
    }
}
