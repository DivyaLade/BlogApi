namespace BlogApi.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content {  get; set; }
        public int AuthorId {  get; set; }
        public int CommentId {  get; set; }
    }
}
