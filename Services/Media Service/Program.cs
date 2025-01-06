using AutoMapper;
using Media_Service.Database;
using Media_Service.Models;
using Media_Service.Repositories;
using Media_Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Enable logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Logs to the console

// Add services to the container.
builder.Services.AddControllers();

// Swagger setup for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext for SQLite connection
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Register scoped services (repositories and services)
builder.Services.AddScoped<IMediaDatabase, MediaDatabase>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IAutoCompleteService, AutoCompleteService>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")  // Vue.js app URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Allow credentials if needed
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Shows detailed error pages in development
}
else
{
    app.UseExceptionHandler("/error"); // For production, uses a global error handler
}

// Global error handling for production (optional)

// Use CORS before any other middleware
app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
