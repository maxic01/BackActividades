using Microsoft.EntityFrameworkCore;
using BackActividades.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DbAngularContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
   
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.AllowAnyOrigin();
        app.AllowAnyMethod();
        app.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Nueva Politica");
app.UseAuthorization();

app.MapControllers();

app.Run();
