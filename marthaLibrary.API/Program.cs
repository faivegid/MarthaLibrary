using marthaLibrary.Config;
using marthaLibrary.Config.Middlewares;
using marthaLibrary.CoreData;
using marthaLibrary.Managers;
using marthaLibrary.Models;
using marthaLibrary.Repos;
using marthaLibrary.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbConfigurations(config);
builder.Services.AddMappingToModelsFromAppSettings(config);
builder.Services.AddUnitOfWork();
builder.Services.AddLibraryServices();
builder.Services.AddLibraryManagers();

builder.Services.ConfigureLibrarySecurity(config);

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
