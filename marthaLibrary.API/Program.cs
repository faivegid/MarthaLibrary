using Hangfire;
using marthaLibrary.Config;
using marthaLibrary.Config.Middlewares;
using marthaLibrary.CoreData;
using marthaLibrary.Managers;
using marthaLibrary.Models;
using marthaLibrary.Repos;
using marthaLibrary.Services;
using marthaLibrary.Services.JobServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbConfigurations(config);
builder.Services.AddMappingToModelsFromAppSettings(config);
builder.Services.AddUnitOfWork();
builder.Services.AddLibraryServices();
builder.Services.AddLibraryManagers();
builder.Services.AddLibraryJobs(config);

builder.Services.ConfigureLibrarySecurity(config);
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(GetXmlCommentPath());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHangfireDashboard("/hangfire");
RecurringJob.AddOrUpdate<ReservationMonitoringJob>(job => job.CheckReservation(), "0 * * * *");

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetXmlCommentPath()
{
    var basePath = AppContext.BaseDirectory;
    var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
    return Path.Combine(basePath, fileName);
}