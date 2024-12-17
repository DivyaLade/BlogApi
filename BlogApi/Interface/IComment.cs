using BlogApi.Entities;

namespace BlogApi.Interface
{
    public interface IComment
    {
        Task<List<Comment>> GetAll();
        Task<Comment?> AddComment(Comment comment);
    }
}
