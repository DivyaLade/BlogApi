using BlogApi.Context;
using BlogApi.Interface;
using BlogApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlogApi
{
    public class StartUp
    {
        private readonly IConfiguration _configuration;

        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddControllers();
            services.AddSingleton<IBlogPost, BlogPostService>();
            services.AddSingleton<IAuthor, AuthorService>();
            services.AddSingleton<IComment,  CommentService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            //app.UseMiddleware<JwtMiddleware>();
            app.MapControllers();

        }

    }
} 

