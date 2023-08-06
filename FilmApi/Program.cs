using FilmApi.DbContexts;
using FilmApi.Service;
using FilmApi.Service.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
//sql server config
builder.Services.AddDbContext<ApplicationDbContext>(options
  => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddScoped<IMovieService, MovieService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
policy.WithOrigins("https://localhost:4200/", "http://localhost:4200/")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
    );
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
