using BlogApi.Entities;

namespace BlogApi.Interface
{
    public interface IAuthor
    {
        Task<Author> GetById(int id);
        Task<Author?> AddAuthor(Author author);
    }
}
