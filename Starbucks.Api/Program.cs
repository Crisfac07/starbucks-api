using Core.Mappy.Extensions;
using Core.Mappy.Interfaces;
using Starbucks.Api.Extensions;
using Starbucks.Api.Middleware;
using Starbucks.Application;
using Starbucks.Application.Categories.DTOs;
using Starbucks.Persistence;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();
var mapping = app.Services.GetRequiredService<IMapper>();
mapping.RegisterMappings(typeof(CategoryMappingProfile).Assembly);

await app.ApplyMigration(environment);


app.UseMiddleware<ExceptionHandlingMiddleware>(); 

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
