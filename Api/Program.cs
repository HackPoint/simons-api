using Application;
using Infrastructure;
using Infrastructure.Common.Middleware;
using Prometheus;
const string corsApplication = "corsApplication";
var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

builder.Services.AddControllers();

// Add services to the container.
builder.Services
    .AddInfrastructure(configuration)
    .AddApplication()
    .AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    // builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(corsApplication);

//adding metrics related to HTTP
app.UseMiddleware<ResponseMetricMiddleware>();
app.UseMetricServer();

//adding metrics related to HTTP
app.UseHttpMetrics(options=>
{
    options.AddCustomLabel("host", context => context.Request.Host.Host);
});

app.MapControllers();

app.Run();