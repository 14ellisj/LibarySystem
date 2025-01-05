using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Repositories;
using Media_Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IMediaDatabase, MediaDatabase>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IAutoCompleteService, AutoCompleteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    app.UseCors(policy => policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins("http://localhost:5173"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
