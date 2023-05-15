using Microsoft.EntityFrameworkCore;
using student_status_server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentStatusDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("StudentStatusDbContext"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());  //allow all

app.UseAuthorization();

app.MapControllers();

app.Run();
