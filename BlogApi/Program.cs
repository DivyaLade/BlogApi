using BlogApi;
using BlogApi.Context;
using BlogApi.Interface;
using BlogApi.Service;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
var startup =new StartUp(builder.Configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

/*builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();*/

var app = builder.Build();
startup.Configure(app);

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();*/

app.Run();
