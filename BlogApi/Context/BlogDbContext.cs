using BlogApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Context
{
    public class BlogDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public BlogDbContext(IConfiguration configuration, DbContextOptions<BlogDbContext> options) : base(options)
        
        {
            _configuration = configuration;
        }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
           //optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=EfBlogDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }*/
    }
}
