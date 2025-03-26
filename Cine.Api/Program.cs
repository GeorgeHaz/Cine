using Cine.Api.Data;
using Cine.Api.Repository.Implementaciones;
using Cine.Api.Repository.Intefaces;
using Cine.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CineContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
